using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tpmodul8_1302213117
{
    public class Covid
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_demam { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }
        public Covid() { }
        public Covid(string satuan_suhu, int batas_hari_demam, string pesan_ditolak, string pesan_diterima)
        {
            this.satuan_suhu = satuan_suhu;
            this.batas_hari_demam = batas_hari_demam;
            this.pesan_ditolak = pesan_ditolak;
            this.pesan_diterima = pesan_diterima;
        }
    }

    public class CovidConfig
    {
        public Covid config;

        private const string fileLocation = "D:\\Telkom University\\Semester 4\\Konstruksi " +
            "Perangkat Lunak\\Minggu 8\\TP_MOD8_1302213117\\tpmodul8_1302213117\\";
        private const string filePath = fileLocation + "covid_config.json";

        public CovidConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch
            {
                SetDefault();
                WriteNewConfigFile();
            }
        }

        private Covid ReadConfigFile()
        {
            string hasilBaca = File.ReadAllText(filePath);
            config = JsonSerializer.Deserialize<Covid>(hasilBaca);
            return config;
        }

        private void SetDefault()
        {
            string satuan_suhu = "celcius";
            int batas_hari_demam = 14;
            string pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
            string pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
            config = new Covid(satuan_suhu, batas_hari_demam, pesan_ditolak, pesan_diterima);
        }

        private void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };

            string textTulis = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filePath, textTulis);
        }

        public void UbahSatuan()
        {
            if (config.satuan_suhu == "celcius")
            {
                config.satuan_suhu = "fahrenheit";
                WriteNewConfigFile();
            } else if (config.satuan_suhu == "fahrenheit")
            {
                config.satuan_suhu = "celcius";
                WriteNewConfigFile();
            }
        }
    }
}
