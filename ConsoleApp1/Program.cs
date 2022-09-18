internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        int number = 1719820;
        // C# 的库函数 能够将数字转为二进制字符串
        // PadLeft 是字符串处理函数 用于左边添加0
        Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));
        // 虽然第二个参数填进制，但是只有 2 8 10 16 进制可用，其他输入会报异常
        // Console.WriteLine(Convert.ToString(number, 4).PadLeft(32, '0')); // ArgumentException
    }
}