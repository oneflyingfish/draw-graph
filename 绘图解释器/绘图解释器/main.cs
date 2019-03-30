using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace 绘图解释器
{
    public partial class main : Form
    {
        /// <summary>
        /// 解释运行代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void runButton_Click(object sender, EventArgs e)
        {
            //运行初始化
            this.SetDefaultValue();
            this.paintForm.Visible = true;
            this.outputRichTextBox.Text = String.Format("开始运行 {0} : ", System.DateTime.Now.ToLongTimeString());

            //开始执行代码
            Task task = new Task(RunCode);
            task.Start();
        }

        /// <summary>
        /// 解释运行代码
        /// </summary>
        private void RunCode()
        {
            int lengthOfCode = this.codeRichTextBox.TextLength;         //总字符个数
            int index = 0;                                              //指向代码文本的游标
            string currentCode = "";                                    //即将执行的一行代码     
            bool faceComments = false;

            if (lengthOfCode < 1)                                       //不存在代码
            {
                return;
            }

            while (true)
            {
                //运行由于被用户关闭绘图框主动结束
                if (RunStoped)
                {
                    //输出中断提醒
                    this.outputRichTextBox.AppendText("\n");
                    this.outputRichTextBox.SelectionColor = System.Drawing.Color.Red;
                    this.outputRichTextBox.AppendText("警告：本次运行被用户主动结束...");
                    this.outputRichTextBox.ScrollToCaret();
                    return;
                }
                //判断一条语句结束
                if (index >= lengthOfCode)                              //最后一行代码缺少";"
                {
                    currentCode = currentCode.Trim();
                    if (currentCode.Length > 0)
                    {
                        int lineNumber = this.codeRichTextBox.GetLineFromCharIndex(index - 1) + 1;
                        this.outputRichTextBox.AddTextForRichTextBox(2, currentCode, this.codeRichTextBox.GetLineFromCharIndex(index - 1) + 1, "后面缺少;");
                        errorTimes++;
                        RunOneLineofCode(currentCode, lineNumber);  //出错处理：主动加上";"使得代码继续执行
                    }
                    currentCode = "";

                    this.printEndInformation();
                    return;//判断结束
                }
                else if (this.codeRichTextBox.Text[index] == '\n')      //中间某行代码缺少";"
                {
                    currentCode = currentCode.Trim();
                    if (currentCode.Length > 0)
                    {
                        int lineNumber = this.codeRichTextBox.GetLineFromCharIndex(index - 1) + 1;
                        this.outputRichTextBox.AddTextForRichTextBox(2, currentCode, lineNumber, "后面缺少;");
                        errorTimes++;
                        RunOneLineofCode(currentCode, lineNumber);  //出错处理：主动加上";"使得代码继续执行
                    }
                    currentCode = "";
                    faceComments = false;
                    index++;
                    continue;
                }

                //跳过注释
                if (faceComments == true)
                {
                    index++;
                    continue;
                }

                //判断 ';'、"//"、"--" 等特殊标识
                if (this.codeRichTextBox.Text[index] == '/')
                {
                    if (currentCode.EndsWith("/"))
                    {
                        faceComments = true;
                        currentCode = currentCode.Substring(0, currentCode.Length - 1);
                    }
                    else
                    {
                        currentCode += "/";
                    }
                }
                else if (this.codeRichTextBox.Text[index] == '-')       //遇见注释标记
                {
                    if (currentCode.EndsWith("-"))
                    {
                        faceComments = true;
                        currentCode = currentCode.Substring(0, currentCode.Length - 1);
                    }
                    else
                    {
                        currentCode += "-";
                    }
                }
                else if (this.codeRichTextBox.Text[index] == ';')       //识别到一行正确的代码，执行它
                {
                    currentCode = currentCode.Trim();
                    if (currentCode.Length > 0)
                    {
                        RunOneLineofCode(currentCode, this.codeRichTextBox.GetLineFromCharIndex(index - 1) + 1);
                    }
                    currentCode = "";
                }
                else
                {
                    currentCode += this.codeRichTextBox.Text[index];
                }
                index++;
            }
        }

        /// <summary>
        /// 运行逻辑上（';'决定）的一行代码
        /// </summary>
        /// <param name="code"></param>
        /// <param name="lineNumber"></param>
        private void RunOneLineofCode(string code, int lineNumber = -1)
        {
            //词法分析返回记号流
            List<Mark> marks = GetMarkStream(code);
            //获得语句功能
            CodeFunction codeFunction = GetCodeFunction(code, marks, lineNumber);

            //程序暂时不存在语法错误
            if (errorTimes == 0)
            {
                //执行语义
                RunCodeFunction(codeFunction);

                //多进程执行语义
                //Task task = new Task(RunCodeFunction, codeFunction);
                //task.Start();
                this.outputRichTextBox.AddTextForRichTextBox(1, code, lineNumber);
            }
            else
            {
                this.paintForm.Visible = false;
            }
        }

        /// <summary>
        /// 执行语义
        /// </summary>
        /// <param name="codeFunction">描述语句功能的类</param>
        private void RunCodeFunction(object arg)
        {
            if (!(arg is CodeFunction))
            {
                MessageBox.Show("内部错误，RuncodeFunction参数传递出错");
                return;
            }
            CodeFunction codeFunction = arg as CodeFunction;
            switch (codeFunction.codeType)
            {
                case CodeType.Origin:
                    originX = codeFunction.arg[0];
                    originY = codeFunction.arg[1];
                    break;
                case CodeType.Rot:
                    rotAngle = codeFunction.arg[0];
                    break;
                case CodeType.Scale:
                    scaleX = codeFunction.arg[0];
                    scaleY = codeFunction.arg[1];
                    break;
                case CodeType.For:
                    double t = codeFunction.arg[0];
                    double endT = codeFunction.arg[1];
                    double stepWidth = codeFunction.arg[2];
                    List<Mark> xFormula = codeFunction.argsFormula[3];
                    List<Mark> yFormula = codeFunction.argsFormula[4];
                    while (t < endT)
                    {
                        double x = 0, y = 0;
                        if (!Calculate.CalculateExpression(xFormula, out x, t))
                        {
                            this.outputRichTextBox.SelectionColor = System.Drawing.Color.Red;
                            this.outputRichTextBox.AppendText("内部多项式计算器计算x值发生错误\n");
                            return;
                        }

                        if (!Calculate.CalculateExpression(yFormula, out y, t))
                        {
                            this.outputRichTextBox.SelectionColor = System.Drawing.Color.Red;
                            this.outputRichTextBox.AppendText("内部多项式计算器计算y值发生错误\n");
                            return;
                        }

                        //比例变换
                        x = x * scaleX;
                        y = y * scaleY;

                        //旋转变换
                        double xBefore = x;
                        double yBefore = y;
                        x = xBefore * Math.Cos(rotAngle) + yBefore * Math.Sin(rotAngle);
                        y = yBefore * Math.Cos(rotAngle) - xBefore * Math.Sin(rotAngle);

                        //平移变换
                        x = x + originX;
                        y = y + originY;

                        //绘制圆点
                        //this.paintForm.Visible = true;
                        paintGraphics.FillRectangle(new SolidBrush(this.colorLabel.BackColor), float.Parse(x.ToString()), float.Parse(y.ToString()), 1.0F, 1.0F);

                        t += stepWidth;
                    }
                    this.paintForm.pictureBox.Image = bitmap;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 解析语句功能
        /// </summary>
        /// <param name="code"></param>
        /// <param name="marks"></param>
        /// <param name="lineNumber"></param>
        /// <returns></returns>
        private CodeFunction GetCodeFunction(string code, List<Mark> marks, int lineNumber = -1)
        {
            List<Mark> expression = new List<Mark>();
            CodeFunction codeFunction = new CodeFunction();
            List<double> expressionValue = codeFunction.arg;
            int languageindex = 0;      // 表示正在匹配的下标索引
            int inputIndex = 0;

            TokenType[] languageAim = null;

            //匹配语句类型
            switch (marks[0].tokenType)
            {
                case TokenType.Origin:
                    codeFunction.codeType = CodeType.Origin;
                    languageAim = ORIGIN;
                    break;

                case TokenType.Scale:
                    codeFunction.codeType = CodeType.Scale;
                    languageAim = SCALE;
                    break;

                case TokenType.Rot:
                    codeFunction.codeType = CodeType.Rot;
                    languageAim = ROT;
                    break;

                case TokenType.For:
                    codeFunction.codeType = CodeType.For;
                    languageAim = FOR;
                    break;

                default:
                    errorTimes++;
                    outputRichTextBox.AddTextForRichTextBox(2, code, lineNumber, marks[0].originalString + "未定义");
                    return null;
            }

            //开始提取语句功能、参数表达式以及对应值
            while (true)
            {
                //判断结束情况
                if (languageAim[languageindex] == TokenType.End || inputIndex == marks.Count - 1)
                {
                    if (inputIndex < marks.Count - 1)                                             //languageAim先结束
                    {
                        errorTimes++;
                        outputRichTextBox.AddTextForRichTextBox(2, code, lineNumber, "语法错误，似乎语句过长");
                        return null;
                    }
                    else if (languageAim[languageindex] != TokenType.End)                           //marks先结束
                    {
                        errorTimes++;
                        outputRichTextBox.AddTextForRichTextBox(2, code, lineNumber, "语法错误，似乎语句过短");
                        return null;
                    }
                    else if (inputIndex == marks.Count - 1 && languageAim[languageindex] == TokenType.End)    //匹配正确
                    {
                        //语法分析完毕
                        return codeFunction;
                    }
                }

                if (languageAim[languageindex] != TokenType.Expression)             //匹配非表达式
                {
                    if (languageAim[languageindex] == marks[inputIndex].tokenType)
                    {
                        languageindex++;    // languageAim[index]匹配成功
                        inputIndex++;
                        continue;
                    }
                    else
                    {
                        errorTimes++;
                        outputRichTextBox.AddTextForRichTextBox(2, code, lineNumber, marks[inputIndex - 1].originalString + "后面应该是\"" + TokenTypeToString(languageAim[languageindex]) + "\"而不是" + marks[inputIndex].originalString);
                        return null;
                    }
                }
                else if (languageAim[languageindex] == TokenType.Expression)      //匹配表达式
                {
                    //不属于表达式单词
                    if (!(marks[inputIndex].IsOperator() || marks[inputIndex].IsValue() || marks[inputIndex].tokenType == TokenType.Function))
                    {
                        //下一个待匹配为右括号，但是已经被加入到表达式
                        if (languageAim[languageindex + 1] == TokenType.RightBracket)
                        {
                            Mark mark = expression[expression.Count - 1]; //取出表达式中最后一个符号
                            if (mark.tokenType != TokenType.RightBracket)
                            {
                                errorTimes++;
                                outputRichTextBox.AddTextForRichTextBox(2, code, lineNumber, "后面缺少)");
                                return null;
                            }
                            else
                            {
                                expression.RemoveAt(expression.Count - 1); //删除多加进来的右括号
                                double value = 0.0;
                                if (Calculate.CalculateExpression(expression, out value))
                                {
                                    codeFunction.argsFormula.Add(new List<Mark>(expression));
                                    expression.Clear();
                                    expressionValue.Add(value); //按照顺序添加表达式的值
                                    languageindex++;                    //表达式匹配成功
                                    inputIndex--;                        //重新匹配换下来的右括号
                                    continue;
                                }
                                else
                                {
                                    errorTimes++;
                                    outputRichTextBox.AddTextForRichTextBox(2, code, lineNumber, "第" + (expressionValue.Count + 1) + "个double类型的数据表达式不合法");
                                    return null;
                                }
                            }
                        }
                        else        //下一个待匹配不是右括号
                        {
                            double value = 0.0;
                            if (Calculate.CalculateExpression(expression, out value))
                            {
                                codeFunction.argsFormula.Add(new List<Mark>(expression));
                                expression.Clear();
                                expressionValue.Add(value); //第一个表达式的值
                                languageindex++;                    //表达式和右括号均匹配成功
                                continue;
                            }
                            else
                            {
                                errorTimes++;
                                outputRichTextBox.AddTextForRichTextBox(2, code, lineNumber, "第" + (expressionValue.Count + 1) + "个类型的数据表达式不合法");
                                return null;
                            }
                        }
                    }
                    else
                    {
                        expression.Add(marks[inputIndex]);
                        if (inputIndex == marks.Count - 2)
                        {
                            languageindex++;
                        }
                        else
                        {
                            inputIndex++;
                        }
                    }
                }
            }


        }

        /// <summary>
        /// 设置默认值
        /// </summary>
        private void SetDefaultValue()
        {
            this.errorTimes = 0;                // 代码总字符数（包括空格、回车等空白字符）
            this.originX = 0.0;                 // 用于记录x平移距离
            this.originY = 0.0;                 // 用于记录y平移距离
            this.rotAngle = 0.0;                // 用于记录旋转角度
            this.scaleX = 1;                    // 用于记录x比例因子
            this.scaleY = 1;                    // 用于记录y比例因子

            SetDefaultPaintForm();              //重制绘图窗体
        }

        /// <summary>
        /// 对一行语句进行“词法分析”，返回记号流
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private List<Mark> GetMarkStream(string code)
        {
            List<Mark> markStream = new List<Mark>();

            code = code.Replace("**", ";");
            string currentWord = "";
            int index = 0;
            while (true)
            {
                //句子到达尾部
                if (index >= code.Length)
                {
                    if (currentWord.Length > 0)
                    {
                        Mark mark = TokenDictionary.stringToMark(currentWord);
                        markStream.Add(mark);
                    }
                    break;
                }

                char ch = code[index];
                if (ch == ' ')                                                                  //空格分隔单词
                {
                    if (currentWord.Length > 0)
                    {
                        Mark mark = TokenDictionary.stringToMark(currentWord);
                        markStream.Add(mark);
                        currentWord = "";
                    }
                    index++;
                    continue;
                }
                else if (ch == '+' || ch == '-' || ch == '*' || ch == '/' || ch == ';' || ch == ',' || ch == ')' || ch == '(')    //运算符分隔单词，其中","表示"**"，即指数运算
                {
                    if (currentWord.Length > 0)
                    {
                        Mark mark = TokenDictionary.stringToMark(currentWord);
                        markStream.Add(mark);
                        currentWord = "";
                    }
                    markStream.Add(TokenDictionary.stringToMark(ch.ToString()));
                    index++;
                    continue;
                }
                else
                {
                    currentWord += ch;
                    index++;
                }
            }

            //在一行语句的记号流末尾加上结束符(“;”）
            markStream.Add(new Mark(TokenType.NonToke, ";", 0, null));
            markStream.Add(new Mark(TokenType.End, "", 0, null));
            return markStream;
        }

        /// <summary>
        /// 转类型为字符串
        /// </summary>
        /// <param name="tokenType"></param>
        /// <returns></returns>
        private string TokenTypeToString(TokenType tokenType)
        {
            switch (tokenType)
            {
                case TokenType.Origin:
                    return "origin";
                case TokenType.Scale:
                    return "scale";
                case TokenType.Rot:
                    return "rot";
                case TokenType.For:
                    return "for";
                case TokenType.Is:
                    return "is";
                case TokenType.LeftBracket:
                    return "(";
                case TokenType.RightBracket:
                    return ")";
                case TokenType.Comma:
                    return ",";
                case TokenType.From:
                    return "from";
                case TokenType.To:
                    return "to";
                case TokenType.Step:
                    return "step";
                case TokenType.Draw:
                    return "draw";
                case TokenType.T:
                    return "T";
                case TokenType.Expression:
                    return "(表达式)";
                default:
                    return "";
            }
        }

        int errorTimes = 0;                     //代码总字符数（包括空格、回车等空白字符）
        double originX = 0.0, originY = 0.0;    // 用于记录平移距离
        double rotAngle = 0.0;                  // 用于记录旋转角度
        double scaleX = 1, scaleY = 1;          // 用于记录比例因子

        TokenType[] ORIGIN = new TokenType[] { TokenType.Origin, TokenType.Is, TokenType.LeftBracket, TokenType.Expression, TokenType.Comma, TokenType.Expression, TokenType.RightBracket, TokenType.NonToke, TokenType.End };
        TokenType[] SCALE = new TokenType[] { TokenType.Scale, TokenType.Is, TokenType.LeftBracket, TokenType.Expression, TokenType.Comma, TokenType.Expression, TokenType.RightBracket, TokenType.NonToke, TokenType.End };
        TokenType[] ROT = new TokenType[] { TokenType.Rot, TokenType.Is, TokenType.Expression, TokenType.NonToke, TokenType.End };
        TokenType[] FOR = new TokenType[] { TokenType.For, TokenType.T, TokenType.From, TokenType.Expression, TokenType.To, TokenType.Expression, TokenType.Step, TokenType.Expression, TokenType.Draw, TokenType.LeftBracket, TokenType.Expression, TokenType.Comma, TokenType.Expression, TokenType.RightBracket, TokenType.NonToke, TokenType.End };

        //绘图界面是否被用户主动关闭
        bool RunStoped = true;
    }
}
