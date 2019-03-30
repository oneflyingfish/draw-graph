using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 绘图解释器
{
    /// <summary>
    /// 枚举内置关键字类型
    /// </summary>
    public enum TokenType
    {
        None,                                           //无意义，表示不确定的类型
        Origin, Scale, Rot, Is,                         // 保留字（一字一码）
        To, Step, Draw, For, From,                      // 保留字
        T,                                              // 参数
        Semico, LeftBracket, RightBracket, Comma,       // 分隔符 ; ( ) ,
        Plus, Minus, Mul, Div, Power,                   // 运算符        
        Function,                                       // 函数（调用）
        ConstID,                                        // 常数
        NonToke,                                        // 分号
        ErrorToken,                                     // 出错记号（非法输入）
        Expression,                                     // 表达式
        End                                             // 结束标志（源程序结束）
    }

    /// <summary>
    /// 定义一个记号
    /// </summary>
    public class Mark
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="tokenType">符号类型</param>
        /// <param name="originalString">原字符串</param>
        /// <param name="value">当表示的是常量时，其值</param>
        /// <param name="function">当表示的是某个函数时，其函数委托</param>
        public Mark(TokenType tokenType = TokenType.None, string originalString = "", double value = 0.0, Func<double, double> function = null)
        {
            this.tokenType = tokenType;
            this.originalString = originalString;
            this.value = value;
            if(function!=null)
            {
                this.function = function;
            }
        }

        /// <summary>
        /// 获取操作符优先级
        /// </summary>
        /// <returns></returns>
        public int GetPriority()
        {
            TokenType tokenType = this.tokenType;
            if (tokenType == TokenType.Plus || tokenType == TokenType.Minus)
            {
                return 1;
            }
            else if(tokenType == TokenType.Mul || tokenType == TokenType.Div)
            {
                return 2;
            }
            else if(tokenType == TokenType.Power)
            {
                return 3;
            }
            else if(tokenType ==TokenType.Function)
            {
                return 4;
            }
            return 0;
        }

        /// <summary>
        /// 判断是否是+、-、*、/、**、（、）运算符
        /// </summary>
        /// <returns></returns>
        public bool IsOperator()
        {
            TokenType tokenType = this.tokenType;
            if (tokenType == TokenType.Plus || tokenType == TokenType.Minus || tokenType == TokenType.Mul || tokenType == TokenType.Div || tokenType == TokenType.Power || tokenType == TokenType.LeftBracket || tokenType == TokenType.RightBracket)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 判断是否是数值类型
        /// </summary>
        /// <returns></returns>
        public bool IsValue()
        {
            TokenType tokenType = this.tokenType;
            if(tokenType==TokenType.ConstID || tokenType==TokenType.T)
            {
                return true;
            }
            return false;
        }

        public TokenType tokenType;                     //字符串表示的类型
        public string originalString = "";              //原字符串
        public double value = 0.0;                          //原字符串的值
        public Func<double, double> function = null;    //函数执行的函数的委托
    }

    /// <summary>
    /// 记号符号表
    /// </summary>
    public static class TokenDictionary
    {
        public static Mark stringToMark(string str)
        {
            switch (str.ToLower())
            {
                //定义常量
                case "pi":
                    return new Mark(TokenType.ConstID, str, Math.PI, null);
                case "e":
                    return new Mark(TokenType.ConstID, str, Math.E, null);
                //定义变量
                case "t":
                    return new Mark(TokenType.T, str, 0.0, null);
                //定义函数
                case "sin":
                    return new Mark(TokenType.Function, str, 0.0, Math.Sin);
                case "cos":
                    return new Mark(TokenType.Function, str, 0.0, Math.Cos);
                case "tan":
                    return new Mark(TokenType.Function, str, 0.0, Math.Tan);
                case "ln":
                    return new Mark(TokenType.Function, str, 0.0, Math.Log);
                case "exp":
                    return new Mark(TokenType.Function, str, 0.0, Math.Exp);
                case "sqrt":
                    return new Mark(TokenType.Function, str, 0.0, Math.Sqrt);
                //定义关键字
                case "origin":
                    return new Mark(TokenType.Origin, str, 0.0, null);
                case "scale":
                    return new Mark(TokenType.Scale, str, 0.0, null);
                case "rot":
                    return new Mark(TokenType.Rot, str, 0.0, null);
                case "is":
                    return new Mark(TokenType.Is, str, 0.0, null);
                case "for":
                    return new Mark(TokenType.For, str, 0.0, null);
                case "from":
                    return new Mark(TokenType.From, str, 0.0, null);
                case "to":
                    return new Mark(TokenType.To, str, 0.0, null);
                case "step":
                    return new Mark(TokenType.Step, str, 0.0, null);
                case "draw":
                    return new Mark(TokenType.Draw, str, 0.0, null);
                //定义分隔符
                case ",":
                    return new Mark(TokenType.Comma, str, 0.0, null);
                case "(":
                    return new Mark(TokenType.LeftBracket, str, 0.0, null);
                case ")":
                    return new Mark(TokenType.RightBracket, str, 0.0, null);
                //定义运算符
                case "+":
                    return new Mark(TokenType.Plus, str, 0.0, null);
                case "-":
                    return new Mark(TokenType.Minus, str, 0.0, null);
                case "*":
                    return new Mark(TokenType.Mul, str, 0.0, null);
                case "/":
                    return new Mark(TokenType.Div, str, 0.0, null);
                case ";"://之前"**"被替换为";"
                    return new Mark(TokenType.Power, "**", 0.0, null);
                //定义数字常量，解析失败时返回null
                default:
                    return JudgeType(str);
            }
        }

        /// <summary>
        /// 区分字面量和字符串
        /// </summary>
        /// <param name="str"></param>
        private static Mark JudgeType(string str)
        {
            double value = 0;
            //识别为常数字符串
            if(double.TryParse(str,out value))
            {
                return new Mark(TokenType.ConstID, str, value, null);
            }
            return new Mark(TokenType.ErrorToken, str, value, null);
        }

    }
}
