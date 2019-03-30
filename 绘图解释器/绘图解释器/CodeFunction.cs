using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 绘图解释器
{
    /// <summary>
    /// 语句类型
    /// </summary>
    public enum CodeType
    {
        none,
        Origin,
        For,
        Rot,
        Scale
    }

    public class CodeFunction
    {
        public CodeType codeType = CodeType.none;
        public List<double> arg = new List<double>();                       //表达式的值，依照顺序排列
        public List<List<Mark>> argsFormula = new List<List<Mark>>();       //表达式的记号流，依照顺序
    }
}
