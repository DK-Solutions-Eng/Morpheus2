using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public static class Comunicacao
    {
        public static byte[] lastbytes = new byte[24];

        public static bool retorno = false;

        public static double peso { get; set; }

        public static int casadecimais { get; set; }

        public static DateTime dtinicioprocesso;

        public static void calcularPeso(string p1, string p2, string p3, string pmultiplicador, string psinal)
        {
            double multiplicador = getMultiplicador(Convert.ToInt32(pmultiplicador));

            casadecimais = Convert.ToInt32(pmultiplicador);

            if (psinal == "1")
            {
                peso = (((Convert.ToDouble(Convert.ToInt32(p1, 16)) * 65536) + (Convert.ToDouble(Convert.ToInt32(p2, 16)) * 256) + (Convert.ToDouble(Convert.ToInt32(p3, 16)))) * multiplicador) * -1;
            }
            else
            {
                peso = ((Convert.ToDouble(Convert.ToInt32(p1, 16)) * 65536) + (Convert.ToDouble(Convert.ToInt32(p2, 16)) * 256) + (Convert.ToDouble(Convert.ToInt32(p3, 16)))) * multiplicador;
            }

        }

        public static double getMultiplicador(int p)
        {
            if (p == 0)
            {
                return 1;
            }
            else if (p == 1)
            {
                return 0.1;
            }
            else if (p == 2)
            {
                return 0.01;
            }
            else if (p == 3)
            {
                return 0.001;
            }
            else if (p == 4)
            {
                return 0.0001;
            }
            return 0;
        }

        public static bool checkCRCReceived(byte[] comBuffer)
        {
            ushort CRCFull = 0xFFFF;
            byte CRCHigh = 0xFF, CRCLow = 0xFF;
            char CRCLSB;

            for (int i = 0; i < (comBuffer.Length) -2; i++)
            {
                CRCFull = (ushort)(CRCFull ^ comBuffer[i]);

                for (int j = 0; j < 8; j++)
                {
                    CRCLSB = (char)(CRCFull & 0x0001);
                    CRCFull = (ushort)((CRCFull >> 1) & 0x7FFF);

                    if (CRCLSB == 1)
                        CRCFull = (ushort)(CRCFull ^ 0xA001);
                }
            }
            CRCHigh = (byte)((CRCFull >> 8) & 0xFF);
            CRCLow = (byte)(CRCFull & 0xFF);

            if(CRCHigh ==  comBuffer[comBuffer.Length-1])
            {
                if(CRCLow == comBuffer[comBuffer.Length -2])
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public static byte[] setCRC(byte[] comBuffer)
        {
            //Function expects a modbus message of any length as well as a 2 byte CRC array in which to 
            //return the CRC values:

            ushort CRCFull = 0xFFFF;
            byte CRCHigh = 0xFF, CRCLow = 0xFF;
            char CRCLSB;
            byte[] comBufferWithCrc = new byte[comBuffer.Length + 2];
            for (int i = 0; i < (comBuffer.Length);  i++)
            {
                CRCFull = (ushort)(CRCFull ^ comBuffer[i]);

                for (int j = 0; j < 8; j++)
                {
                    CRCLSB = (char)(CRCFull & 0x0001);
                    CRCFull = (ushort)((CRCFull >> 1) & 0x7FFF);

                    if (CRCLSB == 1)
                        CRCFull = (ushort)(CRCFull ^ 0xA001);
                }
            }
            CRCHigh = (byte)((CRCFull >> 8) & 0xFF);
            CRCLow = (byte)(CRCFull & 0xFF);

            for (int i = 0; i < comBuffer.Length; i++)
            {
                comBufferWithCrc[i] = comBuffer[i];
            }
            comBufferWithCrc[comBuffer.Length] = CRCLow;
            comBufferWithCrc[comBuffer.Length + 1] = CRCHigh;

            return comBufferWithCrc;
        }



        public static void valida_crc(List<int> buf, int len)
        {
            //Recebe um array de bytes e valida se os ultimos 2 sao os CRC validos da sequencia, se for valido retorna 1, senao retorna 0.

            Int32 crc = 0xFFFF;
            for (int pos = 0; pos < len; pos++)
            {
                crc ^= (Int32)buf[pos];
                for (int i = 8; i != 0; i--)
                {
                    if ((crc & 0x0001) != 0)
                    {
                        crc >>= 1;
                        crc ^= 0xA001;
                    }
                    else
                    {
                        crc >>= 1;
                    }
                }

                var teste = crc;
                //if (highByte(crc) == buf[len - 1])
                //{
                //    if (lowByte(crc) == buf[len - 2])
                //    {
                //        return 1;
                //    }
                //    else
                //    {
                //        return 0;
                //    }
                //}
                //else
                //{
                //    return 0;
                //}
            }
        }

        public static bool validaRetorno()
        {
            dtinicioprocesso = DateTime.Now;
            while (!Common.Comunicacao.retorno)
            {
                if ((dtinicioprocesso.AddSeconds(10) < DateTime.Now))
                {
                    MessageBox.Show("Falha no envio do comando, tente novamente!");
                    return false;
                }
            }
            return true;
        }

    }
}