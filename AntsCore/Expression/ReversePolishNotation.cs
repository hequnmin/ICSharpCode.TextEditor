using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Globalization;

namespace AntsCore.Expression
{

    /// <summary>
    /// 操作数类型
    /// </summary>
    public enum Type
    {
        /// <summary>
        /// 函数
        /// </summary>
        FUNC = 1,

        /// <summary>
        /// 日期
        /// </summary>
        DATE = 2,

        /// <summary>
        /// 数字
        /// </summary>
        NUMBER = 3,

        /// <summary>
        /// 布尔
        /// TODO 
        /// </summary>
        BOOLEAN = 4,

        /// <summary>
        /// 字符串
        /// </summary>
        STRING = 5
    }

    /// <summary>
    /// 运算符类型(从上到下优先级依次递减)，数值越大，优先级越低
    /// </summary>
    public enum OperatorType
    {
        #region 最高优先级操作符

        /// <summary>
        /// 左括号:(,left bracket
        /// </summary>
        LB = 1,

        /// <summary>
        /// 右括号),right bracket
        /// </summary>
        RB = 2,

        /// <summary>
        /// 逻辑非,!,NOT
        /// </summary>
        NOT = 3,

        /// <summary>
        /// 正号,+,positive sign
        /// </summary>
        PS = 5,

        /// <summary>
        /// 负号,-,negative sign
        /// </summary>
        NS = 7,

        #endregion

        #region 函数

        /// <summary>
        /// 正切，tan
        /// </summary>
        TAN = 10,

        /// <summary>
        /// 正切，tan
        /// </summary>
        COT = 11,

        /// <summary>
        /// 反正切，atan
        /// </summary>
        ATAN = 12,

        /// <summary>
        /// 正弦
        /// </summary>
        SIN = 13,

        /// <summary>
        /// 余弦
        /// </summary>
        COS = 14,

        /// <summary>
        /// 绝对值
        /// </summary>
        Abs = 15,

        /// <summary>
        /// 开平方
        /// </summary>
        Sqrt = 16,

        /// <summary>
        /// 向下取整
        /// </summary>
        Floor = 17,

        /// <summary>
        /// 向上取整
        /// </summary>
        Ceiling = 18,

        /// <summary>
        /// 四舍五入2位小数
        /// </summary>
        Round = 19,

        /// <summary>
        /// 平方
        /// </summary>
        Pow = 20,

        /// <summary>
        /// 立方
        /// </summary>
        Cube = 21,

        /// <summary>
        /// 自然对数
        /// </summary>
        Ln = 22,

        /// <summary>
        /// 10为底的对数
        /// </summary>
        Log = 23,

        /// <summary>
        /// 十六进制
        /// </summary>
        Hex = 24,

        /// <summary>
        /// 十进制
        /// </summary>
        Dec = 25,

        /// <summary>
        /// 检索子字符串
        /// </summary>
        Substring = 26,

        /// <summary>
        /// 0~1随机数
        /// </summary>
        Random = 27,

        /// <summary>
        /// 返回设置的日期
        /// </summary>
        Date = 28,

        /// <summary>
        /// 当前日期
        /// </summary>
        Today = 29,

        /// <summary>
        /// 当前时间
        /// </summary>
        Now = 30,

        Year = 31,
        Month = 32,
        Day = 33,

        /// <summary>
        /// 条件判断
        /// </summary>
        If = 80,

        #endregion

        #region 其他操作符

        /// <summary>
        /// 乘,*,multiplication
        /// </summary>
        MUL = 130,

        /// <summary>
        /// 除,/,division
        /// </summary>
        DIV = 131,

        /// <summary>
        /// 余,%,modulus
        /// </summary>
        MOD = 132,

        /// <summary>
        /// 加,+,Addition
        /// </summary>
        ADD = 140,

        /// <summary>
        /// 减,-,subtraction
        /// </summary>
        SUB = 141,

        /// <summary>
        /// 小于,less than
        /// </summary>
        LT = 150,

        /// <summary>
        /// 小于或等于,less than or equal to
        /// </summary>
        LE = 151,

        /// <summary>
        /// 大于,>,greater than
        /// </summary>
        GT = 152,

        /// <summary>
        /// 大于或等于,>=,greater than or equal to
        /// </summary>
        GE = 153,

        /// <summary>
        /// 等于,=,equal to
        /// </summary>
        ET = 160,

        /// <summary>
        /// 不等于,unequal to
        /// </summary>
        UT = 161,

        /// <summary>
        /// 逻辑与,&,AND
        /// </summary>
        AND = 170,

        /// <summary>
        /// 逻辑或,|,OR
        /// </summary>
        OR = 171,

        /// <summary>
        /// 逗号,comma
        /// </summary>
        CA = 180,

        /// <summary>
        /// 结束符号 @
        /// </summary>
        END = 255,

        /// <summary>
        /// 错误符号
        /// </summary>
        ERR = 256

        #endregion

    }

    /// <summary>
    /// 操作数类
    /// </summary>
    public class Operand
    {
        public Operand(Type type, object value)
        {
            this.Type = type;
            this.Value = value;
        }

        public Operand(string opd, object value)
        {
            this.Type = ConvertOperand(opd);
            this.Value = value;
        }

        ~Operand()
        {
        }

        /// <summary>
        /// 操作数类型
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// 关键字
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 操作数值
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// 转换操作数到指定的类型
        /// </summary>
        /// <param name="opd">操作数</param>
        /// <returns>返回对应的操作数类型</returns>
        public static Type ConvertOperand(string opd)
        {
            if (opd.IndexOf("(") > -1)
            {
                return Type.FUNC;
            }
            else if (IsNumber(opd))
            {
                return Type.NUMBER;
            }
            else if (IsDate(opd))
            {
                return Type.DATE;
            }
            else
            {
                return Type.STRING;
            }
        }

        /// <summary>
        /// 判断对象是否为数字
        /// </summary>
        /// <param name="value">对象值</param>
        /// <returns>是返回真,否返回假</returns>
        public static bool IsNumber(object value)
        {
            return Regex.IsMatch(value.ToString(), @"^[+-]?\d*[.]?\d*$");
            // return double.TryParse(value.ToString(), out _); 用正则表达式快一点
        }

        /// <summary>
        /// 判断对象是否为日期
        /// </summary>
        /// <param name="value">对象值</param>
        /// <returns>是返回真,否返回假</returns>
        public static bool IsDate(object value)
        {
            //return DateTime.TryParse(value.ToString(), out _);
            return DateTime.TryParse(value.ToString().Replace("\"", ""), out _);     //日期字符串带有分界符，此处滤除分界符
        }
    }

    /// <summary>
    /// 运算符类
    /// </summary>
    public class Operator
    {
        public Operator(OperatorType type, string value)
        {
            this.Type = type;
            this.Value = value;
        }

        ~Operator()
        {
        }

        /// <summary>
        /// 运算符类型
        /// </summary>
        public OperatorType Type { get; set; }

        /// <summary>
        /// 运算符值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 对于>或者&lt;运算符，判断实际是否为>=,&lt;&gt;、&lt;=，并调整当前运算符位置
        /// </summary>
        /// <param name="currentOpt">当前运算符</param>
        /// <param name="currentExp">当前表达式</param>
        /// <param name="currentOptPos">当前运算符位置</param>
        /// <returns>返回调整后的运算符</returns>
        public static string AdjustOperator(string currentOpt, string currentExp, ref int currentOptPos)
        {
            #region 操作符 <>

            if (currentOpt == "<")
            {
                if (currentExp.Substring(currentOptPos, 2) == "<=")
                {
                    currentOptPos++;
                    return "<=";
                }

                if (currentExp.Substring(currentOptPos, 2) != "<>") return "<";
                currentOptPos++;
                return "<>";
            }
            else if (currentOpt == ">")
            {
                if (currentExp.Substring(currentOptPos, 2) == ">=")
                {
                    currentOptPos++;
                    return ">=";
                }

                return ">";
            }
            else if (currentOpt == "=")
            {
                if (currentExp.Substring(currentOptPos, 2) == "==")
                {
                    currentOptPos++;
                    return "==";
                }

                return "=";
            }

            #endregion

            var firstChar = false; // currentOpt是否和函数的首字母匹配
            var funcs = new List<string>
            {
                "tan","cot", "atan", "sin", "cos",
                "abs", "sqrt",
                "floor", "ceiling",
                "round", "pow", "cube", "ln", "log", "hex", "dec", "substring", "random",
                "date", "today", "now", "year", "month", "day",
                "if"
            };

            foreach (var func in funcs)
            {
                var first = func.Substring(0, 1);
                if (currentExp.StartsWith(first, StringComparison.CurrentCultureIgnoreCase))
                    firstChar = true;

                if (!currentExp.StartsWith(func, StringComparison.CurrentCultureIgnoreCase))
                    continue;

                currentOptPos += func.Length - 1;
                return func;
            }

            return firstChar ? "error" : currentOpt;
        }

        /// <summary>
        /// 转换运算符到指定的类型
        /// </summary>
        /// <param name="opt">运算符</param>
        /// <param name="isBinaryOperator">是否为二元运算符</param>
        /// <returns>返回指定的运算符类型</returns>
        public static OperatorType ConvertOperator(string opt, bool isBinaryOperator)
        {
            switch (opt)
            {
                case "!": return OperatorType.NOT;
                case "+": return isBinaryOperator ? OperatorType.ADD : OperatorType.PS;
                case "-": return isBinaryOperator ? OperatorType.SUB : OperatorType.NS;
                case "*": return isBinaryOperator ? OperatorType.MUL : OperatorType.ERR;
                case "/": return isBinaryOperator ? OperatorType.DIV : OperatorType.ERR;
                case "%": return isBinaryOperator ? OperatorType.MOD : OperatorType.ERR;
                case "<": return isBinaryOperator ? OperatorType.LT : OperatorType.ERR;
                case ">": return isBinaryOperator ? OperatorType.GT : OperatorType.ERR;
                case "<=": return isBinaryOperator ? OperatorType.LE : OperatorType.ERR;
                case ">=": return isBinaryOperator ? OperatorType.GE : OperatorType.ERR;
                case "<>": return isBinaryOperator ? OperatorType.UT : OperatorType.ERR;
                case "=": return isBinaryOperator ? OperatorType.ET : OperatorType.ERR;
                case "&": return isBinaryOperator ? OperatorType.AND : OperatorType.ERR;
                case "|": return isBinaryOperator ? OperatorType.OR : OperatorType.ERR;
                case ",": return isBinaryOperator ? OperatorType.CA : OperatorType.ERR;
                case "@": return isBinaryOperator ? OperatorType.END : OperatorType.ERR;
                default: return OperatorType.ERR;
            }
        }

        /// <summary>
        /// 转换运算符到指定的类型
        /// </summary>
        /// <param name="opt">运算符</param>
        /// <returns>返回指定的运算符类型</returns>
        public static OperatorType ConvertOperator(string opt)
        {
            opt = opt.ToLower(); // svn add 307

            switch (opt)
            {
                case "~": return OperatorType.NS;
                case "!": return OperatorType.NOT;
                case "+": return OperatorType.ADD;
                case "-": return OperatorType.SUB;
                case "*": return OperatorType.MUL;
                case "/": return OperatorType.DIV;
                case "%": return OperatorType.MOD;
                case "<": return OperatorType.LT;
                case ">": return OperatorType.GT;
                case "<=": return OperatorType.LE;
                case ">=": return OperatorType.GE;
                case "<>": return OperatorType.UT;
                //case "=": return OptType.ET;
                case "==": return OperatorType.ET;
                case "&": return OperatorType.AND;
                case "|": return OperatorType.OR;
                case ",": return OperatorType.CA;
                case "@": return OperatorType.END;
                case "tan": return OperatorType.TAN;
                case "cot": return OperatorType.COT;
                case "atan": return OperatorType.ATAN;
                case "sin": return OperatorType.SIN; // svn add 307
                case "cos": return OperatorType.COS;
                case "abs": return OperatorType.Abs;
                case "sqrt": return OperatorType.Sqrt;
                case "floor": return OperatorType.Floor;
                case "ceiling": return OperatorType.Ceiling;
                case "round": return OperatorType.Round;
                case "pow": return OperatorType.Pow;
                case "cube": return OperatorType.Cube;
                case "ln": return OperatorType.Ln;
                case "log": return OperatorType.Log;
                case "hex": return OperatorType.Hex;
                case "dec": return OperatorType.Dec;
                case "substring": return OperatorType.Substring;
                case "random": return OperatorType.Random;
                case "date": return OperatorType.Date;
                case "today": return OperatorType.Today;
                case "now": return OperatorType.Now;
                case "year": return OperatorType.Year;
                case "month": return OperatorType.Month;
                case "day": return OperatorType.Day;
                case "if": return OperatorType.If;
                default: return OperatorType.ERR;
            }
        }

        /// <summary>
        /// 运算符是否为二元运算符,该方法有问题，暂不使用
        /// </summary>
        /// <param name="tokens">语法单元堆栈</param>
        /// <param name="operators">运算符堆栈</param>
        /// <param name="currentOpd">当前操作数</param>
        /// <returns>是返回真,否返回假</returns>
        public static bool IsBinaryOperator(ref Stack<object> tokens, ref Stack<Operator> operators, string currentOpd)
        {
            if (currentOpd != "")
            {
                return true;
            }
            else
            {
                object token = tokens.Peek();
                if (token is Operand)
                {
                    if (operators.Peek().Type != OperatorType.LB)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (((Operator)token).Type == OperatorType.RB)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// 运算符优先级比较
        /// </summary>
        /// <param name="optA">运算符类型A</param>
        /// <param name="optB">运算符类型B</param>
        /// <returns>A与B相比，-1，低；0,相等；1，高</returns>
        public static int ComparePriority(OperatorType optA, OperatorType optB)
        {
            if (optA == optB)
            {
                //A、B优先级相等
                return 0;
            }

            //乘,除,余(*,/,%)
            if ((optA >= OperatorType.MUL && optA <= OperatorType.MOD) &&
                (optB >= OperatorType.MUL && optB <= OperatorType.MOD))
            {
                return 0;
            }
            //加,减(+,-)
            if ((optA >= OperatorType.ADD && optA <= OperatorType.SUB) &&
                (optB >= OperatorType.ADD && optB <= OperatorType.SUB))
            {
                return 0;
            }
            //小于,小于或等于,大于,大于或等于(<,<=,>,>=)
            if ((optA >= OperatorType.LT && optA <= OperatorType.GE) &&
                (optB >= OperatorType.LT && optB <= OperatorType.GE))
            {
                return 0;
            }
            //等于,不等于(=,<>)
            if ((optA >= OperatorType.ET && optA <= OperatorType.UT) &&
                (optB >= OperatorType.ET && optB <= OperatorType.UT))
            {
                return 0;
            }
            //函数  
            if (optA >= OperatorType.TAN && optA < OperatorType.MUL && optB >= OperatorType.TAN && optB < OperatorType.MUL)
            {
                return 0;
            }

            if (optA < optB)
            {
                //A优先级高于B
                return 1;
            }

            //A优先级低于B
            return -1;
        }
    }


    /// <summary>
    /// Reverse Polish Notation
    /// 逆波兰表示法
    /// </summary>
    public class ReversePolishNotation
    {
        public ReversePolishNotation()
        {
        }

        ~ReversePolishNotation()
        {
        }

        /// <summary>
        /// 最终逆波兰式堆栈
        /// </summary>
        public Stack<object> Tokens { get; } = new Stack<object>();

        /// <summary>
        /// 允许使用的运算符
        /// </summary>
        public readonly List<string> m_Operators = new List<string>(new[]
        {
            "(", "tan", ")", "atan", "cot", "sin", "cos", "abs", "sqrt", "floor", "ceiling",
            "round", "pow","cube","ln","log",
            "hex", "dec", "substring", "random",
            "date", "today", "now", "year", "month", "day",
            "if",
            "~", "!", "*", "/", "%", "+", "-", "<", ">", "=", "&", "|", ",", "@"
        });

        /// <summary>
        /// 检查表达式中特殊符号(双引号、单引号、井号、左右括号)是否匹配      
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        private static bool IsMatching(string exp)
        {
            string opt = "";    //临时存储 " ' # (

            for (int i = 0; i < exp.Length; i++)
            {
                string chr = exp.Substring(i, 1);   //读取每个字符
                if ("\"'#".Contains(chr))   //当前字符是双引号、单引号、井号的一种
                {
                    if (opt.Contains(chr))  //之前已经读到过该字符
                    {
                        opt = opt.Remove(opt.IndexOf(chr), 1);  //移除之前读到的该字符，即匹配的字符
                    }
                    else
                    {
                        opt += chr;     //第一次读到该字符时，存储
                    }
                }
                else if ("()".Contains(chr))    //左右括号
                {
                    if (chr == "(")
                    {
                        opt += chr;
                    }
                    else if (chr == ")")
                    {
                        if (opt.Contains("("))
                        {
                            opt = opt.Remove(opt.IndexOf("("), 1);
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return (opt == "");
        }

        /// <summary>
        /// 从表达式中查找运算符位置
        /// </summary>
        /// <param name="exp">表达式</param>
        /// <param name="findOpt">要查找的运算符</param>
        /// <returns>返回运算符位置</returns>
        private int FindOperator(string exp, string findOpt)
        {
            var opt = "";
            for (var i = 0; i < exp.Length; i++)
            {
                var chr = exp.Substring(i, 1);
                if ("\"'#".Contains(chr))//忽略双引号、单引号、井号中的运算符
                {
                    if (opt.Contains(chr))
                    {
                        opt = opt.Remove(opt.IndexOf(chr), 1);
                    }
                    else
                    {
                        opt += chr;
                    }
                }

                if (opt != "")
                    continue;

                if (findOpt != "")
                {
                    if (findOpt == chr)
                    {
                        return i;
                    }
                }
                else
                {
                    //modify svn 307 忽略大小写
                    if (m_Operators.Exists(x => x.IndexOf(chr, StringComparison.CurrentCultureIgnoreCase) > -1))
                        return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 解析数学表达式
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public bool Parse(string exp)
        {
            #region 容错

            Tokens.Clear();//清空语法单元堆栈
            if (exp.Trim() == "")//表达式不能为空
                return false;
            else if (!IsMatching(exp))//括号、引号、单引号等必须配对
                return false;

            exp = exp.Trim();
            exp = exp.Replace("（", "(");
            exp = exp.Replace("）", ")");
            exp = exp.Replace("！", "!");
            exp = exp.Replace("\\", "/");

            exp = exp.Replace("PI", $"({Math.PI})");

            exp = exp.Replace("\r", "");
            exp = exp.Replace("\n", "");
            if (exp.StartsWith("="))        //以=号开头的公式，去除=号
                exp = exp.Substring(1);

            #endregion

            //return true;
            exp = ReplaceNegative(exp);

            #region 解析

            var nums = new Stack<object>();         //操作数堆栈
            var operators = new Stack<Operator>();      //运算符堆栈
            var optType = OperatorType.ERR;             //运算符类型
            var curNum = "";                            //当前操作数
            var curOpt = "";                            //当前运算符
            var curPos = 0;                             //当前位置
            var funcCount = 0;                          //函数数量

            curPos = FindOperator(exp, "");

            exp += "@"; //结束操作符
            while (true)
            {
                curPos = FindOperator(exp, "");

                curNum = exp.Substring(0, curPos).Trim();
                curOpt = exp.Substring(curPos, 1);

                //存储当前操作数到操作数堆栈
                if (curNum != "")
                    nums.Push(new Operand(curNum, curNum));

                //若当前运算符为结束运算符，则停止循环
                if (curOpt == "@")
                    break;

                //若当前运算符为左括号,则直接存入堆栈。
                if (curOpt == "(")
                {
                    operators.Push(new Operator(OperatorType.LB, "("));
                    exp = exp.Substring(curPos + 1).Trim();
                    continue;
                }

                //若当前运算符为右括号,则依次弹出运算符堆栈中的运算符并存入到操作数堆栈,直到遇到左括号为止,此时抛弃该左括号.
                if (curOpt == ")")
                {
                    while (operators.Count > 0)
                    {
                        if (operators.Peek().Type != OperatorType.LB)
                        {
                            nums.Push(operators.Pop());
                        }
                        else
                        {
                            operators.Pop();
                            break;
                        }
                    }
                    exp = exp.Substring(curPos + 1).Trim();
                    continue;
                }

                //调整运算符 获得完整函数名
                curOpt = Operator.AdjustOperator(curOpt, exp, ref curPos);

                optType = Operator.ConvertOperator(curOpt);

                //若运算符堆栈为空,或者若运算符堆栈栈顶为左括号,则将当前运算符直接存入运算符堆栈.
                if (operators.Count == 0 || operators.Peek().Type == OperatorType.LB)
                {
                    operators.Push(new Operator(optType, curOpt));
                    exp = exp.Substring(curPos + 1).Trim();
                    continue;
                }

                //若当前运算符优先级大于运算符栈顶的运算符,则将当前运算符直接存入运算符堆栈顶部.
                if (Operator.ComparePriority(optType, operators.Peek().Type) > 0)
                {
                    operators.Push(new Operator(optType, curOpt));
                }
                else
                {
                    //若当前运算符若比运算符堆栈栈顶的运算符优先级低或相等，则输出栈顶运算符到操作数堆栈，
                    //直至运算符栈栈顶运算符低于（不包括等于）该运算符优先级，
                    //或运算符栈栈顶运算符为左括号
                    //并将当前运算符压入运算符堆栈。
                    while (operators.Count > 0)
                    {
                        if (Operator.ComparePriority(optType, operators.Peek().Type) <= 0 &&
                            operators.Peek().Type != OperatorType.LB)
                        {
                            nums.Push(operators.Pop());

                            if (operators.Count != 0)
                                continue;

                            operators.Push(new Operator(optType, curOpt));
                            break;
                        }
                        else
                        {
                            operators.Push(new Operator(optType, curOpt));
                            break;
                        }
                    }

                }
                exp = exp.Substring(curPos + 1).Trim();
            }
            //转换完成,若运算符堆栈中尚有运算符时,
            //则依序取出运算符到操作数堆栈,直到运算符堆栈为空
            while (operators.Count > 0)
            {
                nums.Push(operators.Pop());
            }
            //调整操作数栈中对象的顺序并输出到最终栈
            while (nums.Count > 0)
            {
                Tokens.Push(nums.Pop());
            }

            return true;

            #endregion
        }

        /// <summary>
        /// 将正负号替换为 # @
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public string ReplaceNegative(string exp)
        {
            var len = exp.Length;
            var expT = exp.ToArray();
            var symbols = new[] { '+', '-', '*', '/', '^', '(', ',', '<', '>', '=' };

            for (var i = len - 1; i > -1; i--)
            {
                if (expT[i] == '-' && i > 1)
                    if (symbols.Contains(exp[i - 1]))
                        expT[i] = '~';

                if (expT[i] == '-' && i == 1)
                    expT[i] = '~';


                if (expT[i] == '+' && i > 1)
                    if (symbols.Contains(exp[i - 1]))
                        expT[i] = '#';

                if (expT[i] == '+' && i == 1)
                    expT[i] = '#';
            }

            //exp = string.Join("", expT).Replace("#", "");     // 1+2计算公式都错误，Min
            exp = string.Join("", expT).Replace("#", "+");

            return exp;
        }

        /// <summary>
        /// 对逆波兰表达式求值
        /// </summary>
        /// <returns></returns>
        public object Evaluate()
        {
            /*
              逆波兰表达式求值算法：
              1、循环扫描语法单元的项目。
              2、如果扫描的项目是操作数，则将其压入操作数堆栈，并扫描下一个项目。
              3、如果扫描的项目是一个二元运算符，则对栈的顶上两个操作数执行该运算。
              4、如果扫描的项目是一个一元运算符，则对栈的最顶上操作数执行该运算。
              5、将运算结果重新压入堆栈。
              6、重复步骤2-5，堆栈中即为结果值。
            */

            try
            {
                if (Tokens.Count == 0) return null;

                object value = null;
                var opds = new Stack<Operand>();
                var pars = new Stack<object>();
                Operand opdA;
                Operand opdB;
                Operand opdC;
                foreach (var item in Tokens)
                {
                    if (item is Operand operand)
                    {
                        //如果为操作数则压入操作数堆栈
                        opds.Push(operand);
                    }
                    else
                    {
                        switch (((Operator)item).Type)
                        {
                            #region 其他

                            case OperatorType.LB:
                                continue;
                            case OperatorType.RB:
                                continue;
                            case OperatorType.PS:
                                continue;

                            #endregion

                            #region ~ Negtive 取负数

                            case OperatorType.NS:
                                opdA = opds.Pop();
                                if (Operand.IsNumber(opdA.Value))
                                {
                                    opds.Push(new Operand(Type.NUMBER,
                                        -1.0 * double.Parse(opdA.Value.ToString())));
                                }
                                else
                                {
                                    throw new Exception("Negative运算的操作数必须为数字");
                                }
                                break;

                            #endregion

                            #region 乘,*,multiplication
                            case OperatorType.MUL:
                                opdA = opds.Pop();
                                opdB = opds.Pop();
                                if (Operand.IsNumber(opdA.Value) && Operand.IsNumber(opdB.Value))
                                {
                                    opds.Push(new Operand(Type.NUMBER, double.Parse(opdB.Value.ToString()) * double.Parse(opdA.Value.ToString())));
                                }
                                else
                                {
                                    throw new Exception("乘运算的两个操作数必须均为数字");
                                }
                                break;
                            #endregion

                            #region 除,/,division
                            case OperatorType.DIV:
                                opdA = opds.Pop();
                                opdB = opds.Pop();
                                if (Operand.IsNumber(opdA.Value) && Operand.IsNumber(opdB.Value))
                                {
                                    opds.Push(new Operand(Type.NUMBER, double.Parse(opdB.Value.ToString()) / double.Parse(opdA.Value.ToString())));
                                }
                                else
                                {
                                    throw new Exception("除运算的两个操作数必须均为数字");
                                }
                                break;
                            #endregion

                            #region 余,%,modulus
                            case OperatorType.MOD:
                                opdA = opds.Pop();
                                opdB = opds.Pop();
                                if (Operand.IsNumber(opdA.Value) && Operand.IsNumber(opdB.Value))
                                {
                                    opds.Push(new Operand(Type.NUMBER, double.Parse(opdB.Value.ToString()) % double.Parse(opdA.Value.ToString())));
                                }
                                else
                                {
                                    throw new Exception("余运算的两个操作数必须均为数字");
                                }
                                break;
                            #endregion

                            #region 加,+,Addition

                            case OperatorType.ADD:
                                opdA = opds.Pop();
                                if (opds.Count > 0)
                                {
                                    opdB = opds.Pop();
                                    if (Operand.IsNumber(opdA.Value) && Operand.IsNumber(opdB.Value))
                                    {
                                        opds.Push(new Operand(Type.NUMBER, double.Parse(opdB.Value.ToString()) + double.Parse(opdA.Value.ToString())));
                                    }
                                    else
                                    {
                                        //throw new Exception("加运算的两个操作数必须均为数字");
                                        //若两个操作数有一为字符串，则进行字符串加运算  Min 2020-09-01
                                        if (opdA.Type == Type.STRING || opdB.Type == Type.STRING)
                                        {
                                            opds.Push(new Operand(Type.STRING,
                                                $"\"{opdB.Value.ToString().Trim(' ', '\t', '\n', '\v', '\f', '\r', '\'', '\\', '"')}{opdA.Value.ToString().Trim(' ', '\t', '\n', '\v', '\f', '\r', '\'', '\\', '"')}\"")
                                                );
                                        }
                                        else
                                        {
                                            throw new Exception("加运算的两个操作数必须均为数字或字符串");
                                        }
                                    }
                                    break;
                                }
                                throw new Exception("加运算的操作数必须均为数字");

                            #endregion

                            #region 减,-,subtraction
                            case OperatorType.SUB:
                                opdA = opds.Pop();
                                if (opds.Count > 0)
                                {
                                    opdB = opds.Pop();
                                    if (Operand.IsNumber(opdA.Value) && Operand.IsNumber(opdB.Value))
                                        opds.Push(new Operand(Type.NUMBER,
                                            double.Parse(opdB.Value.ToString()) - double.Parse(opdA.Value.ToString())));
                                    else
                                        throw new Exception("减运算的两个操作数必须均为数字");
                                    break;
                                }
                                throw new Exception("减运算的操作数必须均为数字");

                            #endregion

                            #region 逻辑运算符 true 1 false -1

                            case OperatorType.NOT: // 非
                                opdA = opds.Pop();
                                if (Operand.IsNumber(opdA.Value))
                                    opds.Push(
                                        new Operand(Type.NUMBER,
                                            double.Parse($"{opdA.Value}") > 0 ? -1 : 1)
                                    );
                                else
                                    throw new Exception("加运算的两个操作数必须均为数字");
                                break;

                            case OperatorType.LT:
                                opdA = opds.Pop();
                                opdB = opds.Pop();
                                if (opdA.Type == Type.NUMBER && opdB.Type == Type.NUMBER)
                                {
                                    opds.Push(new Operand(Type.BOOLEAN, double.Parse(opdB.Value.ToString()) < double.Parse(opdA.Value.ToString()) ? true : false));
                                }
                                else
                                {
                                    throw new Exception("小于运算符的两个操作数必须数字");
                                }
                                break;
                            case OperatorType.LE:
                                opdA = opds.Pop();
                                opdB = opds.Pop();
                                if (opdA.Type == Type.NUMBER && opdB.Type == Type.NUMBER)
                                {
                                    opds.Push(new Operand(Type.BOOLEAN, double.Parse(opdB.Value.ToString()) <= double.Parse(opdA.Value.ToString()) ? true : false));
                                }
                                else
                                {
                                    throw new Exception("小于等于运算符的两个操作数必须数字");
                                }
                                break;
                            case OperatorType.GT:
                                opdA = opds.Pop();
                                opdB = opds.Pop();
                                if (opdA.Type == Type.NUMBER && opdB.Type == Type.NUMBER)
                                {
                                    opds.Push(new Operand(Type.BOOLEAN, double.Parse(opdB.Value.ToString()) > double.Parse(opdA.Value.ToString()) ? true : false));
                                }
                                else
                                {
                                    throw new Exception("大于运算符的两个操作数必须数字");
                                }
                                break;
                            case OperatorType.GE:
                                opdA = opds.Pop();
                                opdB = opds.Pop();
                                if (opdA.Type == Type.NUMBER && opdB.Type == Type.NUMBER)
                                {
                                    opds.Push(new Operand(Type.BOOLEAN, double.Parse(opdB.Value.ToString()) >= double.Parse(opdA.Value.ToString()) ? true : false));
                                }
                                else
                                {
                                    throw new Exception("大于等于运算符的两个操作数必须数字");
                                }
                                break;
                            case OperatorType.ET:
                                opdA = opds.Pop();
                                opdB = opds.Pop();
                                if (opdA.Type == opdB.Type)
                                {
                                    opds.Push(new Operand(Type.BOOLEAN, (opdA.Value.ToString() == opdB.Value.ToString() ? true : false)));
                                }
                                else
                                {
                                    throw new Exception("等于运算符的两个操作数必须相同");
                                }
                                break;
                            case OperatorType.UT:
                                opdA = opds.Pop();
                                opdB = opds.Pop();
                                if (opdA.Type == opdB.Type)
                                {
                                    opds.Push(new Operand(Type.BOOLEAN, (opdA.Value.ToString() != opdB.Value.ToString() ? true : false)));
                                }
                                else
                                {
                                    throw new Exception("不等于运算符的两个操作数必须相同");
                                }
                                break;
                            case OperatorType.AND:
                                break;
                            case OperatorType.OR:
                                break;
                            case OperatorType.CA:
                                break;

                            #endregion

                            #region 正切,tan,subtraction

                            case OperatorType.TAN:
                                opdA = opds.Pop();
                                if (Operand.IsNumber(opdA.Value))
                                {
                                    opds.Push(new Operand(Type.NUMBER, Math.Tan(double.Parse(opdA.Value.ToString()) * Math.PI / 180)));
                                }
                                else
                                {
                                    throw new Exception("正切运算的1个操作数必须均为角度数字");
                                }
                                break;

                            #endregion

                            #region 余切,cot

                            case OperatorType.COT:
                                opdA = opds.Pop();
                                if (Operand.IsNumber(opdA.Value))
                                {
                                    opds.Push(new Operand(Type.NUMBER,
                                        1.0 / Math.Tan(double.Parse(opdA.Value.ToString()) * Math.PI / 180)));
                                }
                                else
                                {
                                    throw new Exception("余切运算的1个操作数必须均为角度数字");
                                }
                                break;

                            #endregion

                            #region 反正切,atan,subtraction
                            case OperatorType.ATAN:
                                opdA = opds.Pop();
                                if (Operand.IsNumber(opdA.Value))
                                {
                                    opds.Push(new Operand(Type.NUMBER, Math.Atan(double.Parse(opdA.Value.ToString()))));
                                }
                                else
                                {
                                    throw new Exception("反正切运算的1个操作数必须均为数字");
                                }
                                break;
                            #endregion

                            #region 正弦,sin 角度

                            case OperatorType.SIN:
                                opdA = opds.Pop();
                                if (Operand.IsNumber(opdA.Value))
                                {
                                    opds.Push(new Operand(Type.NUMBER,
                                        Math.Sin(double.Parse(opdA.Value.ToString()) * Math.PI / 180)));
                                }
                                else
                                {
                                    throw new Exception("正弦运算的1个操作数必须均为角度数字");
                                }
                                break;

                            #endregion

                            #region 余弦,cos 角度

                            case OperatorType.COS:
                                opdA = opds.Pop();
                                if (Operand.IsNumber(opdA.Value))
                                {
                                    opds.Push(new Operand(Type.NUMBER,
                                        Math.Cos(double.Parse(opdA.Value.ToString()) * Math.PI / 180)));
                                }
                                else
                                {
                                    throw new Exception("正弦运算的1个操作数必须均为角度数字");
                                }
                                break;

                            #endregion

                            #region Abs

                            case OperatorType.Abs:
                                opdA = opds.Pop();
                                if (Operand.IsNumber(opdA.Value))
                                {
                                    opds.Push(new Operand(Type.NUMBER,
                                        Math.Abs(double.Parse(opdA.Value.ToString()))));
                                }
                                else
                                {
                                    throw new Exception("abs运算的1个操作数必须为数字");
                                }
                                break;

                            #endregion

                            #region Floor

                            case OperatorType.Floor:
                                opdA = opds.Pop();
                                if (Operand.IsNumber(opdA.Value))
                                {
                                    opds.Push(new Operand(Type.NUMBER,
                                        Math.Floor(double.Parse(opdA.Value.ToString()))));
                                }
                                else
                                {
                                    throw new Exception("Floor运算的1个操作数必须为数字");
                                }
                                break;

                            #endregion

                            #region Ceiling

                            case OperatorType.Ceiling:
                                opdA = opds.Pop();
                                if (Operand.IsNumber(opdA.Value))
                                {
                                    opds.Push(new Operand(Type.NUMBER,
                                        Math.Ceiling(double.Parse(opdA.Value.ToString()))));
                                }
                                else
                                {
                                    throw new Exception("Ceiling运算的1个操作数必须为数字");
                                }
                                break;

                            #endregion

                            #region 开平方 Sqrt

                            case OperatorType.Sqrt:
                                opdA = opds.Pop();
                                if (Operand.IsNumber(opdA.Value))
                                {
                                    opds.Push(new Operand(Type.NUMBER,
                                        Math.Sqrt(double.Parse(opdA.Value.ToString()))));
                                }
                                else
                                {
                                    throw new Exception("sqrt运算的1个操作数必须为非负数");
                                }
                                break;

                            #endregion

                            #region 四舍五入

                            case OperatorType.Round:
                                opdA = opds.Pop();
                                if (opds.Count > 0)
                                {
                                    opdB = opds.Pop();
                                    if (opdA.Type == Type.NUMBER && opdB.Type == Type.NUMBER)
                                    {
                                        opds.Push(new Operand(Type.NUMBER,
                                            Math.Round(double.Parse(opdB.Value.ToString()), int.Parse(opdA.Value.ToString()))));
                                    }
                                    else
                                    {
                                        throw new Exception("四舍五入运算的两个操作数必须是数字");
                                    }
                                }
                                else
                                {
                                    if (opdA.Type == Type.NUMBER)
                                    {
                                        opds.Push(new Operand(Type.NUMBER,
                                            Math.Round(double.Parse(opdA.Value.ToString()), 2)));
                                    }
                                    else
                                    {
                                        throw new Exception("四舍五入运算的1个操作数必须是数字");
                                    }
                                }
                                break;

                            #endregion

                            #region 幂

                            case OperatorType.Pow:
                                opdA = opds.Pop();
                                if (Operand.IsNumber(opdA.Value))
                                {
                                    opds.Push(new Operand(Type.NUMBER,
                                        Math.Pow(double.Parse(opdA.Value.ToString()), 2)));
                                }
                                else
                                {
                                    throw new Exception("幂运算的1个操作数必须是数字");
                                }
                                break;

                            case OperatorType.Cube:
                                opdA = opds.Pop();
                                if (Operand.IsNumber(opdA.Value))
                                {
                                    opds.Push(new Operand(Type.NUMBER,
                                        Math.Pow(double.Parse(opdA.Value.ToString()), 3)));
                                }
                                else
                                {
                                    throw new Exception("幂运算的1个操作数必须是数字");
                                }
                                break;

                            #endregion

                            #region 对数

                            case OperatorType.Ln:
                                opdA = opds.Pop();
                                if (Operand.IsNumber(opdA.Value))
                                {
                                    opds.Push(new Operand(Type.NUMBER,
                                        Math.Log(double.Parse(opdA.Value.ToString()))));
                                }
                                else
                                    throw new Exception("对数运算的1个操作数必须是数字");
                                break;

                            case OperatorType.Log:
                                opdA = opds.Pop();
                                if (Operand.IsNumber(opdA.Value))
                                {
                                    opds.Push(new Operand(Type.NUMBER,
                                        Math.Log10(double.Parse(opdA.Value.ToString()))));
                                }
                                else
                                    throw new Exception("对数运算的1个操作数必须是数字");
                                break;
                            #endregion

                            #region 其他函数
                            case OperatorType.Hex:
                                opdA = opds.Pop();
                                if (Operand.IsNumber(opdA.Value))
                                {
                                    opds.Push(new Operand(Type.STRING,
                                        Convert.ToInt64(opdA.Value).ToString("X")));
                                }
                                else
                                    throw new Exception("十六进制运算的1个操作数必须是数字");
                                break;
                            case OperatorType.Dec:
                                opdA = opds.Pop();
                                if (opdA.Type == Type.STRING)
                                {
                                    opds.Push(new Operand(Type.NUMBER,
                                        long.Parse(opdA.Value.ToString().Trim(' ', '\t', '\n', '\v', '\f', '\r', '\'', '\\', '"'), NumberStyles.HexNumber)));
                                }
                                else
                                {
                                    throw new Exception("十进制运算的1个操作数必须是字符串");
                                }
                                break;
                            case OperatorType.Random:
                                if (opds.Count <= 0)
                                {
                                    Random rand = new Random();
                                    opds.Push(new Operand(Type.NUMBER, rand.NextDouble()));
                                }
                                else
                                {
                                    throw new Exception("随机数运算的无需操作数");
                                }
                                break;
                            case OperatorType.Substring:
                                opdA = opds.Pop();
                                if (opds.Count > 0)
                                {
                                    opdB = opds.Pop();
                                    if (opds.Count > 0)
                                    {
                                        opdC = opds.Pop();
                                        if (opdC.Type == Type.STRING && opdB.Type == Type.NUMBER && opdA.Type == Type.NUMBER)
                                        {
                                            opds.Push(new Operand(Type.STRING,
                                                opdC.Value.ToString().Substring(int.Parse(opdB.Value.ToString()), int.Parse(opdA.Value.ToString()))));
                                        }
                                        else
                                        {
                                            throw new Exception("检索子字符串函数第一参数必须是字符串，第二和第三参数必须是数值.");
                                        }
                                    }
                                    else
                                    {
                                        if (opdB.Type == Type.STRING && opdA.Type == Type.NUMBER)
                                        {
                                            opds.Push(new Operand(Type.STRING,
                                                opdB.Value.ToString().Substring(int.Parse(opdA.Value.ToString()))));
                                        }
                                        else
                                        {
                                            throw new Exception("检索子字符串函数第一参数必须是字符串，第二参数必须是数值.");
                                        }
                                    }
                                }
                                else
                                {
                                    throw new Exception($"检索子字符串函数必须3个参数.");
                                }
                                break;
                            case OperatorType.Date:
                                if (opds.Count >= 3)
                                {
                                    opdA = opds.Pop();
                                    opdB = opds.Pop();
                                    opdC = opds.Pop();
                                    DateTime dateTime = new DateTime(int.Parse(opdC.Value.ToString()), int.Parse(opdB.Value.ToString()), int.Parse(opdA.Value.ToString()));
                                    opds.Push(new Operand(Type.DATE, dateTime.ToString("yyyy-MM-dd")));
                                }
                                else
                                {
                                    throw new Exception("日期函数的需3个操作数");
                                }
                                break;
                            case OperatorType.Today:
                                if (opds.Count <= 0)
                                {
                                    string today = DateTime.Today.ToString("yyyy-MM-dd");
                                    opds.Push(new Operand(Type.DATE, today));
                                }
                                else
                                {
                                    throw new Exception("当前日期函数的无需操作数");
                                }
                                break;
                            case OperatorType.Now:
                                if (opds.Count <= 0)
                                {
                                    string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff");
                                    opds.Push(new Operand(Type.DATE, now));
                                }
                                else
                                {
                                    throw new Exception("当前时间函数的无需操作数");
                                }
                                break;
                            case OperatorType.Year:
                                if (opds.Count > 0)
                                {
                                    opdA = opds.Pop();
                                    if (opdA.Type == Type.DATE)
                                    {
                                        DateTime dateTime = DateTime.Parse(opdA.Value.ToString());
                                        opds.Push(new Operand(Type.NUMBER, dateTime.Year));
                                    }
                                    else
                                    {
                                        throw new Exception("年份函数的操作数必须是日期类型");
                                    }
                                }
                                else
                                {
                                    throw new Exception("年份函数的需1个日期类型操作数");
                                }
                                break;
                            case OperatorType.Month:
                                if (opds.Count > 0)
                                {
                                    opdA = opds.Pop();
                                    if (opdA.Type == Type.DATE)
                                    {
                                        DateTime dateTime = DateTime.Parse(opdA.Value.ToString());
                                        opds.Push(new Operand(Type.NUMBER, dateTime.Month));
                                    }
                                    else
                                    {
                                        throw new Exception("月份函数的操作数必须是日期类型");
                                    }
                                }
                                else
                                {
                                    throw new Exception("月份函数的需1个日期类型操作数");
                                }
                                break;
                            case OperatorType.Day:
                                if (opds.Count > 0)
                                {
                                    opdA = opds.Pop();
                                    if (opdA.Type == Type.DATE)
                                    {
                                        DateTime dateTime = DateTime.Parse(opdA.Value.ToString());
                                        opds.Push(new Operand(Type.NUMBER, dateTime.Day));
                                    }
                                    else
                                    {
                                        throw new Exception("第几天函数的操作数必须是日期类型");
                                    }
                                }
                                else
                                {
                                    throw new Exception("第几天函数的需1个日期类型操作数");
                                }
                                break;
                            case OperatorType.If:
                                opdA = opds.Pop();
                                opdB = opds.Pop();
                                opdC = opds.Pop();
                                if (opdC.Type == Type.BOOLEAN)
                                {
                                    if (bool.Parse(opdC.Value.ToString()))
                                    {
                                        opds.Push(new Operand(opdB.Type, opdB.Value));
                                    }
                                    else
                                    {
                                        opds.Push(new Operand(opdA.Type, opdA.Value));
                                    }
                                }
                                break;
                            #endregion

                            case OperatorType.END:
                                break;
                            case OperatorType.ERR:
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                }

                if (opds.Count == 1)
                    value = opds.Pop().Value;

                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    
        public bool Validate()
        {
            if (Tokens.Count == 0) return false;
            foreach (var item in Tokens)
            {
                if (item is Operand operand)
                {
                    
                }
                else
                {
                    if (((Operator)item).Type == OperatorType.ERR)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }

}
