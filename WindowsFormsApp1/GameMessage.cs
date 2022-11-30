using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class GameMessage
    {
        public enum MsgType
        {
            Text, Prepare, CanclePrepare, AttackRequest, AttackResponse, HeadStart
        }

        private byte[] data;
        private MsgType type;

        private GameMessage(byte[] data, MsgType type)
        {
            this.type = type;
            this.data = data;
        }

        public ArraySegment<byte>[] GetSendSegments()
        {
            ArraySegment<byte>[] sendSegment = new ArraySegment<byte>[2];
            sendSegment[0] = new ArraySegment<byte> (new byte[] { (byte)type });
            sendSegment[1] = new ArraySegment<byte> (data);
            return sendSegment;
        }

        public MsgType GetMsgType()
        {
            return type;
        }

        public static GameMessage ParseBytes(byte[] data, int len)
        {
            MsgType type = (MsgType) data[0];
            byte[] data1 = new byte[len + 10];
            Array.Copy(data, 1, data1, 0, len);
            return new GameMessage(data1, type);
        }
        public static GameMessage ParseArraySegment(ArraySegment<byte> segment, int len)
        {
            return ParseBytes(segment.ToArray(), len);
        }

        public static GameMessage GetTextMsg(string text)
        {
            return new GameMessage(Encoding.UTF8.GetBytes(text), MsgType.Text);
        }
        public static GameMessage GetPrepareMsg()
        {
            return new GameMessage(new byte[1], MsgType.Prepare);
        }
        public static GameMessage GetCanclePrepareMsg()
        {
            return new GameMessage(new byte[1], MsgType.CanclePrepare);
        }
        public static GameMessage GetAttackRequestMsg(int column, int row)
        {
            return new GameMessage(new byte[] { (byte)column, (byte)row }, MsgType.AttackRequest);
        }
        public static GameMessage GetAttackResponseMsg(int column, int row, AircraftWarGame.CellType cell)
        {
            return new GameMessage(new byte[] { (byte)column, (byte)row, (byte)cell }, MsgType.AttackResponse);
        }
        public static GameMessage GetHeadStartMsg(bool serverFirst)
        {
            return new GameMessage(new byte[1] { (byte)(serverFirst ? 1 : 0) }, MsgType.HeadStart);
        }
        public static string GetText(GameMessage msg)
        {
            return Encoding.UTF8.GetString(msg.data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <returns>[column, row]</returns>
        public static Tuple<int,int> GetAttackRequest(GameMessage msg)
        {
            return Tuple.Create((int)msg.data[0], (int)msg.data[1]);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <returns>[column, row, type]</returns>
        public static Tuple<int, int, AircraftWarGame.CellType> GetAttackResponse(GameMessage msg)
        {
            return Tuple.Create((int)msg.data[0], (int)msg.data[1], (AircraftWarGame.CellType)msg.data[2]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <returns>如果接收者先手，返回True</returns>
        public static bool GetHeadStart(GameMessage msg)
        {
            return msg.data[0] == 0;
        }
    }
}
