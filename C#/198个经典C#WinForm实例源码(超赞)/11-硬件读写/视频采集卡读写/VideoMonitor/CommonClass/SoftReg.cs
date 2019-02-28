using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace VideoMonitor.CommonClass
{
    class SoftReg
    {
        // ȡ���豸Ӳ�̵ľ���
        public string GetDiskVolumeSerialNumber()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"d:\"");
            disk.Get();
            return disk.GetPropertyValue("VolumeSerialNumber").ToString();
        }

        //���CPU�����к�
        public string getCpu()
        {
            string strCpu = null;
            ManagementClass myCpu = new ManagementClass("win32_Processor");
            ManagementObjectCollection myCpuConnection = myCpu.GetInstances();
            foreach (ManagementObject myObject in myCpuConnection)
            {
                strCpu = myObject.Properties["Processorid"].Value.ToString();
                break;
            }
            return strCpu;
        }

        //���ɻ�����
        public string getMNum()
        {
            string strNum = getCpu() + GetDiskVolumeSerialNumber();//���24λCpu��Ӳ�����к�
            string strMNum = strNum.Substring(0,24);//�����ɵ��ַ�����ȡ��ǰ24���ַ���Ϊ������
            return strMNum;
        }

        public int[] intCode = new int[127];//�洢��Կ
        public int[] intNumber = new int[25];//��������Asciiֵ
        public char[] Charcode = new char[25];//�洢��������

        public void setIntCode()//�����鸳ֵС��10����
        {
            for (int i = 1; i < intCode.Length; i++)
            {
                intCode[i] = i % 9;
            }
        }

        //����ע����
        public string getRNum()
        {
            setIntCode();//��ʼ��127λ����
            for (int i = 1; i < Charcode.Length; i++)//�ѻ��������������
            {
                Charcode[i] = Convert.ToChar(this.getMNum().Substring(i - 1, 1));
            }
            for (int j = 1; j < intNumber.Length; j++)//���ַ���ASCIIֵ����һ���������С�
            {
                intNumber[j] = intCode[Convert.ToInt32(Charcode[j])] + Convert.ToInt32(Charcode[j]);
            }
            string strAsciiName = "";//���ڴ洢ע����
            for (int j = 1; j < intNumber.Length; j++)
            {
                if (intNumber[j] >= 48 && intNumber[j] <= 57)//�ж��ַ�ASCIIֵ�Ƿ�0��9֮��
                {
                    strAsciiName += Convert.ToChar(intNumber[j]).ToString();
                }
                else if (intNumber[j] >= 65 && intNumber[j] <= 90)//�ж��ַ�ASCIIֵ�Ƿ�A��Z֮��
                {
                    strAsciiName += Convert.ToChar(intNumber[j]).ToString();
                }
                else if (intNumber[j] >= 97 && intNumber[j] <= 122)//�ж��ַ�ASCIIֵ�Ƿ�a��z֮��
                {
                    strAsciiName += Convert.ToChar(intNumber[j]).ToString();
                }
                else//�ж��ַ�ASCIIֵ�������Ϸ�Χ��
                {
                    if (intNumber[j] > 122)//�ж��ַ�ASCIIֵ�Ƿ����z
                    {
                        strAsciiName += Convert.ToChar(intNumber[j] - 10).ToString();
                    }
                    else
                    {
                        strAsciiName += Convert.ToChar(intNumber[j] - 9).ToString();
                    }
                }
            }
            return strAsciiName;
        }
    }
}
