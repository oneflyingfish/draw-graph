using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 绘图解释器
{
    static class Calculate
    {
        /// <summary>
        /// 逆波兰算法，求解符号流表示的表达式的值
        /// </summary>
        /// <param name="expression">多项式的符号流</param>
        /// <param name="result">计算结果</param>
        /// <param name="t">参数t的值,默认为0</param>
        /// <returns></returns>
        public static bool CalculateExpression(List<Mark> expression, out double result, double t = 0)
        {
            if (expression.Count < 1)
            {
                result = 0.0;
                return false;
            }

            //+ -为单目运算符的情况，前面添加0变成双目运算符
            for (int i = 0; i < expression.Count; i++)
            {
                if (expression[i].tokenType == TokenType.Plus || expression[i].tokenType == TokenType.Minus)
                {
                    if (i == 0)
                    {
                        expression.Insert(i + 2, new Mark(TokenType.RightBracket, "）", 0, null));
                        expression.Insert(i, new Mark(TokenType.ConstID, "0", 0, null));
                        expression.Insert(i, new Mark(TokenType.LeftBracket, "(", 0, null));
                        continue;
                    }
                    else if (i > 0)
                    {
                        if (expression[i - 1].tokenType == TokenType.LeftBracket)
                        {
                            expression.Insert(i + 2, new Mark(TokenType.RightBracket, "）", 0, null));
                            expression.Insert(i, new Mark(TokenType.ConstID, "0", 0, null));
                            expression.Insert(i, new Mark(TokenType.LeftBracket, "(", 0, null));
                            continue;
                        }
                    }
                }
            }

            Stack<Mark> symbolStack = new Stack<Mark>();    //临时存储运算符
            Stack<Mark> resultStack = new Stack<Mark>();    //存储后缀表达式

            //中缀表达式转化为后缀表达式
            for (int i = 0; i < expression.Count; i++)
            {
                if (expression[i].IsValue())                             //下一个字符为数值型
                {
                    resultStack.Push(expression[i]);
                    continue;
                }
                else if (expression[i].IsOperator())                    //下一个字符为运算符
                {
                    //输入符号为右括号，一直出栈，直到遇到左括号
                    if (expression[i].tokenType == TokenType.RightBracket)
                    {
                        while (true)
                        {
                            //符号栈中找不到左括号
                            if (symbolStack.Count <= 0)
                            {
                                result = 0;
                                return false;
                            }

                            //部分运算符从符号栈进入结果栈
                            Mark mark = symbolStack.Pop();
                            if (mark.tokenType == TokenType.LeftBracket)
                            {
                                break;
                            }
                            else
                            {
                                resultStack.Push(mark);
                            }
                        }
                        continue;
                    }
                    else if (expression[i].tokenType == TokenType.LeftBracket)
                    {
                        symbolStack.Push(expression[i]);
                        continue;
                    }
                    else //+ 、- 、* 、/ 、**
                    {
                        while (true)
                        {
                            //栈内没有符号
                            if (symbolStack.Count <= 0)
                            {
                                symbolStack.Push(expression[i]);
                                break;
                            }

                            Mark mark = symbolStack.Pop();
                            if (mark.GetPriority() < expression[i].GetPriority()) //栈顶元素优先级大于待添加元素
                            {
                                symbolStack.Push(mark);
                                symbolStack.Push(expression[i]);
                                break;
                            }
                            else
                            {
                                resultStack.Push(mark);
                            }
                        }
                        continue;
                    }
                }
                else if (expression[i].tokenType == TokenType.Function)    //下一个字符为函数
                {
                    symbolStack.Push(expression[i]);
                    continue;
                }
                else
                {
                    //不属于数据和运算符的符号
                    result = 0;
                    return false;
                }
            }

            //获得最终的后缀表达式
            while (symbolStack.Count > 0)
            {
                resultStack.Push(symbolStack.Pop());
            }

            //将后缀表达式栈倒过来
            Stack<Mark> calculateStack = new Stack<Mark>();
            int number = resultStack.Count;
            for (int i = 0; i < number; i++)
            {
                //替换参数T为实数
                Mark mark = resultStack.Pop();
                if (mark.tokenType == TokenType.T)
                {
                    mark.value = t;
                }
                calculateStack.Push(mark);
            }

            //利用栈求值
            Stack<Mark> valueStack = new Stack<Mark>();
            for (int i = 0; i < number; i++)
            {
                Mark mark = calculateStack.Pop();
                if (mark.IsValue())
                {
                    valueStack.Push(mark);
                    continue;
                }
                else if (mark.tokenType == TokenType.Function)
                {
                    if (valueStack.Count < 1)
                    {
                        result = 0;
                        return false;
                    }

                    //取出栈顶元素计算函数值后重新压栈
                    Mark markLeft = valueStack.Pop();
                    double functionValue = mark.function(markLeft.value);
                    Mark functinMark = new Mark(TokenType.ConstID, functionValue.ToString(), functionValue, null);
                    valueStack.Push(functinMark);
                }
                else if (mark.IsOperator())
                {
                    if (valueStack.Count < 2)
                    {
                        result = 0;
                        return false;
                    }

                    //取出栈顶的两个元素，运算出结果后将结果压栈
                    Mark markRight = valueStack.Pop();
                    Mark markLeft = valueStack.Pop();
                    double operateValue = 0.0;
                    switch (mark.tokenType)
                    {
                        case TokenType.Plus:
                            operateValue = markLeft.value + markRight.value;
                            break;
                        case TokenType.Minus:
                            operateValue = markLeft.value - markRight.value;
                            break;
                        case TokenType.Mul:
                            operateValue = markLeft.value * markRight.value;
                            break;
                        case TokenType.Div:
                            operateValue = markLeft.value * 1.0 / markRight.value;
                            break;
                        case TokenType.Power:
                            operateValue = Math.Pow(markLeft.value, markRight.value);
                            break;
                        default:
                            result = 0;
                            return false;
                    }
                    Mark operateMark = new Mark(TokenType.ConstID, operateValue.ToString(), operateValue, null);
                    valueStack.Push(operateMark);
                }
                else
                {
                    result = 0;
                    return false;
                }
            }

            if (valueStack.Count != 1)
            {
                result = 0;
                return false;
            }
            else
            {
                result = valueStack.Pop().value;
                return true;
            }
        }
    }
}
