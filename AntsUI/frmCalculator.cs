using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntsCore.Expression;
using ICSharpCode.TextEditor.Document;
using System.Text.RegularExpressions;

namespace Example
{
    public partial class frmCalculator : Form
    {

        public frmCalculator()
        {
            InitializeComponent();
        }

        private void frmCalculator_Load(object sender, EventArgs e)
        {
            #region
            tvwFunction.Nodes.Clear();
            TreeNode trnOperator = new TreeNode("运算符");
            trnOperator.Nodes.Add(new TreeNode("~  负号"));
            //trnOperator.Nodes.Add(new TreeNode("!  非"));
            trnOperator.Nodes.Add(new TreeNode("+  加"));
            trnOperator.Nodes.Add(new TreeNode("-  减"));
            trnOperator.Nodes.Add(new TreeNode("*  乘"));
            trnOperator.Nodes.Add(new TreeNode("/  除"));
            trnOperator.Nodes.Add(new TreeNode("%  余"));
            tvwFunction.Nodes.Add(trnOperator);
            trnOperator.Expand();

            TreeNode trnNumber = new TreeNode("数值函数");
            trnNumber.Nodes.Add(new TreeNode("tan(number)  正切"));
            trnNumber.Nodes.Add(new TreeNode("cot(number)  余切"));
            trnNumber.Nodes.Add(new TreeNode("atan(number)  反正切"));
            trnNumber.Nodes.Add(new TreeNode("sin(number)  正弦"));
            trnNumber.Nodes.Add(new TreeNode("cos(number)  余弦"));
            trnNumber.Nodes.Add(new TreeNode("abs(number)  绝对值"));
            trnNumber.Nodes.Add(new TreeNode("sqrt(number)  开平方"));
            trnNumber.Nodes.Add(new TreeNode("floor(number)  向下取整"));
            trnNumber.Nodes.Add(new TreeNode("ceiling(number)  向上取整"));
            //trnFunction.Nodes.Add(new TreeNode("round(number[,digits]) 四舍五入"));
            TreeNode trnRound = new TreeNode("round(number,digits)  四舍五入");
            TreeNode trnRoundExample01 = new TreeNode("round(3.14159265,2)  保留两位小数点");
            TreeNode trnRoundExample02 = new TreeNode("round(3.14159265,4)  指定保留小数点");
            trnRound.Nodes.Add(trnRoundExample01);
            trnRound.Nodes.Add(trnRoundExample02);
            trnNumber.Nodes.Add(trnRound);
            trnNumber.Nodes.Add(new TreeNode("pow(number)  平方"));
            trnNumber.Nodes.Add(new TreeNode("cube(number)  立方"));
            trnNumber.Nodes.Add(new TreeNode("ln(number)  自然对数"));
            trnNumber.Nodes.Add(new TreeNode("log(number)  10为底的对数"));
            trnNumber.Nodes.Add(new TreeNode("random()  0~1随机数"));
            trnNumber.Nodes.Add(new TreeNode("hex(number)  十六进制"));
            trnNumber.Nodes.Add(new TreeNode("dec(\"string\")  十进制"));
            trnNumber.Nodes.Add(new TreeNode("PI  圆周率"));
            tvwFunction.Nodes.Add(trnNumber);

            TreeNode trnString = new TreeNode("字符串函数");
            TreeNode trnSubstring = new TreeNode("substring(\"string\",startIndex[,length])  检索子字符串");
            TreeNode trnSubstringExample01 = new TreeNode("substring(\"foobar\",4)  指定开始位置");
            TreeNode trnSubstringExample02 = new TreeNode("substring(\"foobar\",4,3)  指定开始位置指定长度");
            trnSubstring.Nodes.Add(trnSubstringExample01);
            trnSubstring.Nodes.Add(trnSubstringExample02);
            trnString.Nodes.Add(trnSubstring);
            tvwFunction.Nodes.Add(trnString);

            TreeNode trnDate = new TreeNode("日期函数");
            trnDate.Nodes.Add(new TreeNode("date(year,month,day)  返回设置的日期，返回日期格式：yyyy-MM-dd"));
            trnDate.Nodes.Add(new TreeNode("today()  返回当前日期，返回日期格式：yyyy-MM-dd"));
            trnDate.Nodes.Add(new TreeNode("now()  返回当前日期，返回时间格式：yyyy-MM-dd HH:mm:ss fff"));
            trnDate.Nodes.Add(new TreeNode("year(date_value)  返回年份"));
            trnDate.Nodes.Add(new TreeNode("month(date_value)  返回月份"));
            trnDate.Nodes.Add(new TreeNode("day(date_value)  返回月份中第几天"));
            tvwFunction.Nodes.Add(trnDate);

            TreeNode trnLogical = new TreeNode("逻辑符及逻辑函数");
            trnLogical.Nodes.Add(new TreeNode("<  小于"));
            trnLogical.Nodes.Add(new TreeNode(">  大于"));
            trnLogical.Nodes.Add(new TreeNode("<=  小于等于"));
            trnLogical.Nodes.Add(new TreeNode(">=  大于等于"));
            trnLogical.Nodes.Add(new TreeNode("<>  不等于"));
            trnLogical.Nodes.Add(new TreeNode("==  等于"));
            //trnLogical.Nodes.Add(new TreeNode("&  且"));
            //trnLogical.Nodes.Add(new TreeNode("|  或"));
            TreeNode trnIf = new TreeNode("if(logical,value_if_true,value_if_false)  条件判断");
            trnIf.ToolTipText = "判断是否满足某个条件，如果满足返回一个值，如果不满足则返回另一个值。";
            trnLogical.Nodes.Add(trnIf);
            tvwFunction.Nodes.Add(trnLogical);
            #endregion

            txtEditor.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("Expression");
            txtEditor.Encoding = System.Text.Encoding.Default;
            txtEditor.Text = $"={System.Environment.NewLine}1.0+2*3/4-round(floor(4.5)/(7+8),6)+abs(-9)";
            Font font = new Font("Courier New", 14F);
            txtEditor.Font = font;
        }

        private void txtExpression_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    //ReversePolishNotation rpn = new ReversePolishNotation();
                    //string exp = txtExpression.Text;
                    ////exp = Comm.ExpressionReplaceFake(exp, frmMain.config.ConfigCommand.RegexPattern);
                    //txtExpression.Text = exp;
                    //rpn.Parse(exp);
                    //txtResult.Text = rpn.Evaluate().ToString();
                }
                catch(Exception ex)
                {
                    //txtResult.Text = $"error.{ex.Message}";
                }
            }
        }

        public static string ExpressionReplaceFake(string exp, string pattern)
        {
            string expression = exp;
            if (!string.IsNullOrWhiteSpace(expression))
            {
                //正则表达式查找匹配，并替换
                Match match = Regex.Match(expression, pattern, RegexOptions.IgnoreCase);

                Random rnd = new Random();

                while (match.Success)
                {
                    string[] keys;
                    keys = match.Value.Replace("&", "").Split(':');
                    int cmdSort = Convert.ToInt32(Regex.Replace(keys[0], "[a-z]", "", RegexOptions.IgnoreCase));
                    int valSort = Convert.ToInt32(Regex.Replace(keys[1], "[a-z]", "", RegexOptions.IgnoreCase));
                    double value = 0;
                    value = rnd.NextDouble();
                    value = Math.Round(value * 100, 2);
                    expression = expression.Replace(match.Value, value.ToString());

                    match = Regex.Match(expression, pattern, RegexOptions.IgnoreCase);
                }
            }
            return expression;
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            bool validate;
            string exp = txtEditor.Text;

            try
            {
                exp = ExpressionReplaceFake(exp, "&cmd[0-9]:val[0-9]");

                ReversePolishNotation rpn = new ReversePolishNotation();
                rpn.Parse(exp);
                validate = rpn.Validate();

                //string value = rpn.Evaluate().ToString();
            }
            catch (Exception exception)
            {
                txtResult.Clear();
                txtResult.AppendText(exception.Message);
                return;
            }

            if (validate)
            {
                txtResult.Clear();
                txtResult.AppendText("验证通过！");
            }
            else
            {
                txtResult.Clear();
                txtResult.AppendText("语法错误！");
            }


        }

        private void btnEvaldate_Click(object sender, EventArgs e)
        {
            string exp = txtEditor.Text;
            string value;

            try
            {
                exp = ExpressionReplaceFake(exp, "&cmd[0-9]:val[0-9]");

                ReversePolishNotation rpn = new ReversePolishNotation();
                rpn.Parse(exp);

                value = rpn.Evaluate().ToString();
            }
            catch(Exception exception)
            {
                value = exception.Message;
            }

            txtResult.Clear();
            txtResult.AppendText(value);
        }
    }
}
