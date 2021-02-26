using System;

namespace Asn1ToXml
{
    class App
    {
        static void Main(string[] args)
        {
            // Sequence of fields in ASN1 format: https://tls.mbed.org/kb/cryptography/asn1-key-structures-in-der-and-pem
            Console.ReadLine();
            var version = Console.ReadLine();
            var modulus = Console.ReadLine();
            var exponent = Console.ReadLine();
            var d = Console.ReadLine();
            var p = Console.ReadLine();
            var q = Console.ReadLine();
            var dp = Console.ReadLine();
            var dq = Console.ReadLine();
            var inverseQ = Console.ReadLine();

            Console.WriteLine(
                $@"<RSAKeyValue>
<Modulus>{Convert(modulus)}</Modulus>
<Exponent>{Convert(exponent)}</Exponent>
<P>{Convert(p)}</P>
<Q>{Convert(q)}</Q>
<DP>{Convert(dp)}</DP>
<DQ>{Convert(dq)}</DQ>
<InverseQ>{Convert(inverseQ)}</InverseQ>
<D>{Convert(d)}</D>
</RSAKeyValue>");
        }

        private static string Convert(string s)
        {
            s = s.Substring(48);
            var c = s.Length / 2;
            var b = new byte[c];
            for (var i = 0; i < c; i++)
            {
                var d1 = Hex(s[i * 2]);
                var d2 = Hex(s[i * 2 + 1]);
                b[i] = (byte)(d1 * 16 + d2);
            }

            return System.Convert.ToBase64String(b);
        }

        private static byte Hex(char c)
        {
            if (c >= '0' && c <= '9')
                return (byte)(c - '0');
            if (c >= 'A' && c <= 'F')
                return (byte)(c - 'A' + 10);
            if (c >= 'a' && c <= 'f')
                return (byte)(c - 'a' + 10);
            throw new ArgumentException($"Invalid HEX symbol '{c}'");
        }
    }
}
