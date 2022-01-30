namespace Shopping_store
{
    public class Format
    {
        public static string FormatMoney(int money)
        {
            string format = money.ToString("### ### ### ###") + " $";
            return format;
        }
    }
}
