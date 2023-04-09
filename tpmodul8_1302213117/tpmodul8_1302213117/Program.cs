using tpmodul8_1302213117;

internal class Program
{
    private static void Main(string[] args)
    {
        CovidConfig covidConfig = new CovidConfig();
        covidConfig.UbahSatuan();
        Console.WriteLine("Berapa suhu badan anda saat ini? Dalam nilai "+ covidConfig.config.satuan_suhu);
        double suhu = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Berapa hari yang lalu (perkiraan anda terakhir memiliki gejala demam?");
        int hari = Convert.ToInt32(Console.ReadLine());
        if (hari < covidConfig.config.batas_hari_demam)
        {
            if (covidConfig.config.satuan_suhu == "celcius")
            {
                if (suhu >= 36.5 && suhu <= 37.5)
                {
                    Console.WriteLine(covidConfig.config.pesan_diterima);
                }
                else
                {
                    Console.WriteLine(covidConfig.config.pesan_ditolak);
                }
            }
            else if (covidConfig.config.satuan_suhu == "fahrenheit")
            {
                if (suhu >= 97.7 && suhu <= 99.5)
                {
                    Console.WriteLine(covidConfig.config.pesan_diterima);
                }
                else
                {
                    Console.WriteLine(covidConfig.config.pesan_ditolak);
                }
            }
        } else
        {
            Console.WriteLine(covidConfig.config.pesan_ditolak);
        }
    }
}