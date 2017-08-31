using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civ5SaveOptionsChanger
{
    public class Option
    {
        byte[] _ID;
        public byte[] ID
        {
            get
            {
                return _ID;
            }
        }
        int _Value;
        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Present = true;
                _Value = value;
            }
        }
        //byte _Pre;前面的那个字节其实是它的长度。。
        string _Name = "";
        public string Name
        {
            get
            {
                if(_Name=="")
                {
                    return System.Text.Encoding.Default.GetString(_ID);
                }
                else
                {
                    return Name;
                }
            }
            set
            {
                _Name = value;
            }
        }

        public string getLocalName(Dictionary<string,string> Language)
        {
            return Language[Encoding.Default.GetString(ID)];
        }

        bool _Present;
        public bool Present
        {
            get
            {
                return _Present;
            }
            set
            {
                _Present = value;
            }
        }

        public Option(byte[] I, bool P=false, int V=0, string N="")
        {
            _ID =new byte[I.Length];
            I.CopyTo(_ID, 0);
            _Value = V;
            Present = P;
            _Name = N;
        }

        public byte[] getBytes(bool Switch)
        {
            byte[] Result=new byte[ID.Length + 8];
            Result[0] = (byte)ID.Length;
            ID.CopyTo(Result, 4);
            Result[ID.Length + 4] = (byte)(Switch ? 1 : 0);
            return Result;
        }
        public byte[] getBytes()
        {
            byte[] Result = new byte[ID.Length + 8];
            Result[0] = (byte)ID.Length;
            ID.CopyTo(Result, 4);
            Result[ID.Length + 4] = (byte)Value;
            return Result;
        }
    }
    /*
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_QUICK_COMBAT"),0x17),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_QUICK_MOVEMENT"),0x19),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_ONE_CITY_CHALLENGE"),0x1D),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_ALWAYS_PEACE"),0x17),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_ALWAYS_WAR"),0x15),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_NO_CHANGING_WAR_PEACE"),0x20),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_NEW_RANDOM_SEED"),0x1A),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_NO_GOODY_HUTS"),0x18),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_POLICY_SAVING"),0x18),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_NO_TUTORIAL"),0x16),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_NO_HAPPINESS"),0x17),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_PROMOTION_SAVING"),0x1B),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_NO_BARBARIANS"),0x18),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_NO_CITY_RAZING"),0x19),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_NO_ESPIONAGE"),0x17),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_COMPLETE_KILLS"),0x19),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_RANDOM_PERSONALITIES"),0x1F),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_LOCK_MODS"),0x14),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_DISABLE_START_BIAS"),0x1D),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_NO_POLICIES"),0x16),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_NO_SCIENCE"),0x15),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_RAGING_BARBARIANS"),0x1C),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_SIMULTANEOUS_TURNS"),0x1D),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_DYNAMIC_TURNS"),0x18),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_PITBOSS"),0x12)
     */

    class WrongFileException : SystemException
    {
    }
    class Core
    {
        public Option[] Options =
        {
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_QUICK_COMBAT"),true),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_QUICK_MOVEMENT"),true),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_ONE_CITY_CHALLENGE"),true),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_ALWAYS_PEACE")),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_ALWAYS_WAR")),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_NO_CHANGING_WAR_PEACE")),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_NEW_RANDOM_SEED")),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_NO_GOODY_HUTS")),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_POLICY_SAVING")),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_NO_TUTORIAL")),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_NO_HAPPINESS")),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_PROMOTION_SAVING")),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_NO_BARBARIANS")),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_NO_CITY_RAZING")),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_NO_ESPIONAGE")),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_COMPLETE_KILLS")),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_RANDOM_PERSONALITIES")),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_LOCK_MODS")),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_DISABLE_START_BIAS")),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_NO_POLICIES")),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_NO_SCIENCE")),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_RAGING_BARBARIANS")),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_SIMULTANEOUS_TURNS"),true),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_DYNAMIC_TURNS"),true),
            new Option(System.Text.Encoding.Default.GetBytes("GAMEOPTION_PITBOSS"),true)
        };
        int OptionStart=-1;
        int OptionEnd=-1;
        byte[] RawContent;

        public Core(byte[] C)
        {
            RawContent =(byte[]) C.Clone();
            if (!findOptionStartEnd())
            {
                throw new WrongFileException();
            }
            if (!getPresentOptions())
            {
                throw new WrongFileException();
            }
        }

        bool compare(byte[] A,int IA, byte[] B,int IB, int N)
        {
            int i = 0;
            int AL = A.Length - IA, BL = B.Length - IB;
            if (AL < 0 || BL < 0) return false;
            for (;i<AL&&i<BL&&i<N;++i)
            {
                if (A[IA+i] != B[IB+i]) return false;
            }
            if (i == N) return true;
            return false;
        }

        bool compare(int IContent, Option O)
        {
            return compare(RawContent, IContent, O.ID, 0, O.ID.Length);
        }

        bool findOptionStartEnd()
        {
            for (int i=0;i<RawContent.Length;++i)
            {
                if (compare(i,Options[0]))
                {
                    OptionStart = i - 4;
                    continue;
                }
                if(compare(i,Options[Options.Length-1]))
                {
                    OptionEnd = i + Options[Options.Length - 1].ID.Length+4;
                    return true;
                }
            }
            return false;
        }

        int matchOptions(int IContent)
        {
            for (int i=0;i<Options.Length;++i)
            {
                if(compare(IContent,Options[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        bool getPresentOptions()
        {
            if (OptionStart == -1 || OptionEnd == -1) return false;
            for (int i=OptionStart;i<OptionEnd;++i)
            {
                int MO = matchOptions(i);
                if(MO!=-1)
                {
                    Options[MO].Present = true;
                    Options[MO].Value = RawContent[i + Options[MO].ID.Length];
                }
            }
            return true;
        }

        public byte[] output()
        {
            int OptionArrayLength = 0;
            for (int i=0;i<Options.Length;++i)
            {
                if (Options[i].Present) OptionArrayLength += 8 + Options[i].ID.Length;
            }
            int ResultLength = OptionStart + OptionArrayLength + RawContent.Length - OptionEnd;
            byte[] Result = new byte[ResultLength];
            int j = 0;
            for (;j<OptionStart;++j)
            {
                Result[j] = RawContent[j];
            }
            for (int i = 0; i < Options.Length; ++i)
            {
                if (Options[i].Present)
                {
                    Options[i].getBytes().CopyTo(Result, j);
                    j += 8 + Options[i].ID.Length;
                }
            }
            for (int k=OptionEnd;j<ResultLength;++j)
            {
                Result[j] = RawContent[k++];
            }
            return Result;
        }
    }
}
