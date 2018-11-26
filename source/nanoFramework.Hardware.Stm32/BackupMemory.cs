//
// Copyright (c) 2018 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace nanoFramework.Hardware.Stm32
{
    /// <summary>
    /// Provides access to STM32 backup registers.
    /// </summary>
    public static class BackupMemory
    {
        private static int _size = 0;

        /// <summary>
        /// Gets the size of the backup memory on the current target.
        /// </summary>
        public static int Size
        {
            get
            {
                if(_size == 0)
                {
                    _size = GetSize();
                }

                return _size;
            }
        }

        #region Write methods

        /// <summary>
        /// Writes a Boolean value to the backup memory.
        /// </summary>
        /// <param name="position">Position on the backup memory to write the <paramref name="value"/>.</param>
        /// <param name="value">The value to write.</param>
        public static void WriteBoolean(uint position, Boolean value)
        {
            WriteBytes(position, BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Writes a byte value to the backup memory.
        /// </summary>
        /// <param name="position">Position on the backup memory to write the <paramref name="value"/>.</param>
        /// <param name="value">The value to write.</param>
        public static void WriteByte(uint position, Byte value)
        {
            WriteBytes(position, new byte[] { value });
        }

        /// <summary>
        /// Writes a date and time value to the backup memory.
        /// </summary>
        /// <param name="position">Position on the backup memory to write the <paramref name="value"/>.</param>
        /// <param name="value">The value to write.</param>
        public static void WriteDateTime(uint position, DateTime value)
        {
            WriteInt64(position, value.Ticks);
        }

        /// <summary>
        /// Writes a 16-bit integer value to the backup memory.
        /// </summary>
        /// <param name="position">Position on the backup memory to write the <paramref name="value"/>.</param>
        /// <param name="value">The value to write.</param>
        public static void WriteInt16(uint position, Int16 value)
        {
            WriteBytes(position, BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Writes a 32-bit integer value to the backup memory.
        /// </summary>
        /// <param name="position">Position on the backup memory to write the <paramref name="value"/>.</param>
        /// <param name="value">The value to write.</param>
        public static void WriteInt32(uint position, Int32 value)
        {
            WriteBytes(position, BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Writes a 64-bit integer value to the backup memory.
        /// </summary>
        /// <param name="position">Position on the backup memory to write the <paramref name="value"/>.</param>
        /// <param name="value">The value to write.</param>
        public static void WriteInt64(uint position, Int64 value)
        {
            WriteBytes(position, BitConverter.GetBytes(value));
        }


        /// <summary>
        /// Write a floating-point value to the backup memory.
        /// </summary>
        /// <param name="position">Position on the backup memory to write the <paramref name="value"/>.</param>
        /// <param name="value">The value to write.</param>
        public static void WriteSingle(uint position, Single value)
        {
            WriteBytes(position, BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Writes a string value to the backup memory.
        /// </summary>
        /// <param name="position">Position on the backup memory to write the <paramref name="value"/>.</param>
        /// <param name="value">The value to write.</param>
        public static void WriteString(uint position, String value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            byte[] strBytes = Encoding.UTF8.GetBytes(value);
            WriteBytes(position, strBytes);
        }

        /// <summary>
        /// Writes a time interval value to the output stream.
        /// </summary>
        /// <param name="position">Position on the backup memory to write the <paramref name="value"/>.</param>
        /// <param name="value">The value to write.</param>
        public static void WriteTimeSpan(uint position, TimeSpan value)
        {
            WriteInt64(position, value.Ticks);
        }

        /// <summary>
        /// Writes a 16-bit unsigned integer value to the backup memory.
        /// </summary>
        /// <param name="position">Position on the backup memory to write the <paramref name="value"/>.</param>
        /// <param name="value">The value to write.</param>
        public static void WriteUInt16(uint position, UInt16 value)
        {
            WriteBytes(position, BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Writes a 32-bit unsigned integer value to the backup memory.
        /// </summary>
        /// <param name="position">Position on the backup memory to write the <paramref name="value"/>.</param>
        /// <param name="value">The value to write.</param>
        public static void WriteUInt32(uint position, UInt32 value)
        {
            WriteBytes(position, BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Writes a 64-bit unsigned integer value to the backup memory.
        /// </summary>
        /// <param name="position">Position on the backup memory to write the <paramref name="value"/>.</param>
        /// <param name="value">The value to write.</param>
        public static void WriteUInt64(uint position, UInt64 value)
        {
            WriteBytes(position, BitConverter.GetBytes(value));
        }

        #endregion


        #region read methods


        /// <summary>
        /// Reads a Boolean value from the backup memory.
        /// </summary>
        /// <param name="position">Position on the backup memory to read from.</param>
        /// <returns>The value.</returns>
        public static bool ReadBoolean(uint position)
        {
            byte[] buffer = new byte[1];
            ReadBytes(position, buffer);

            return buffer[0] > 0;
        }

        /// <summary>
        /// Reads a byte value from the backup memory.
        /// </summary>
        /// <param name="position">Position on the backup memory to read from.</param>
        /// <returns>The value.</returns>
        public static byte ReadByte(uint position)
        {
            byte[] buffer = new byte[1];
            ReadBytes(position, buffer);

            return buffer[0];
        }

        /// <summary>
        /// Reads a date and time value from the backup memory.
        /// </summary>
        /// <param name="position">Position on the backup memory to read from.</param>
        /// <returns>The value.</returns>
        public static DateTime ReadDateTime(uint position)
        {
            // read position update and check are performed on the call
            return new DateTime(ReadInt64(position));
        }

        /// <summary>
        /// Reads a 16-bit integer value from the backup memory.
        /// </summary>
        /// <param name="position">Position on the backup memory to read from.</param>
        /// <returns>The value.</returns>
        public static short ReadInt16(uint position)
        {
            byte[] buffer = new byte[2];
            ReadBytes(position, buffer);

            var value = BitConverter.ToInt16(buffer, 0);

            return value;
        }

        /// <summary>
        /// Reads a 32-bit integer value from the backup memory.
        /// </summary>
        /// <param name="position">Position on the backup memory to read from.</param>
        /// <returns>The value.</returns>
        public static int ReadInt32(uint position)
        {
            byte[] buffer = new byte[4];
            ReadBytes(position, buffer);

            var value = BitConverter.ToInt32(buffer, 0);

            return value;
        }

        /// <summary>
        /// Reads a 64-bit integer value from the backup memory.
        /// </summary>
        /// <param name="position">Position on the backup memory to read from.</param>
        /// <returns>The value.</returns>
        public static long ReadInt64(uint position)
        {
            byte[] buffer = new byte[8];
            ReadBytes(position, buffer);

            var value = BitConverter.ToInt64(buffer, 0);

            return value;
        }

        /// <summary>
        /// Reads a floating-point value from the backup memory.
        /// </summary>
        /// <param name="position">Position on the backup memory to read from.</param>
        /// <returns>The value.</returns>
        public static float ReadSingle(uint position)
        {
            byte[] buffer = new byte[4];
            ReadBytes(position, buffer);

            var value = BitConverter.ToSingle(buffer, 0);

            return value;
        }

        /// <summary>
        /// Reads a string value from the backup memory.
        /// </summary>
        /// <param name="position">Position on the backup memory to read from.</param>
        /// <param name="lenght">The length of the string.</param>
        /// <returns>The value.</returns>
        public static string ReadString(uint position, UInt32 lenght)
        {
            char[] buffer = new char[lenght];

            byte[] readBuffer = new byte[lenght];
            ReadBytes(position, readBuffer);

            Encoding.UTF8.GetDecoder().Convert(readBuffer, 0, (int)lenght, buffer, 0, (int)lenght, false, out Int32 bytesUsed, out Int32 charsUsed, out Boolean completed);
            var value = new string(buffer, 0, charsUsed);

            return value;
        }

        /// <summary>
        /// Reads a time interval from the backup memory.
        /// </summary>
        /// <param name="position">Position on the backup memory to read from.</param>
        /// <returns>The value.</returns>
        public static TimeSpan ReadTimeSpan(uint position)
        {
            // read position update and check are performed on the call
            return new TimeSpan(ReadInt64(position));
        }

        /// <summary>
        /// Reads a 16-bit unsigned integer from the backup memory.
        /// </summary>
        /// <param name="position">Position on the backup memory to read from.</param>
        /// <returns>The value.</returns>
        public static ushort ReadUInt16(uint position)
        {
            byte[] buffer = new byte[2];
            ReadBytes(position, buffer);

            var value = BitConverter.ToUInt16(buffer, 0);

            return value;
        }

        /// <summary>
        /// Reads a 32-bit unsigned integer from the backup memory.
        /// </summary>
        /// <param name="position">Position on the backup memory to read from.</param>
        /// <returns>The value.</returns>
        public static uint ReadUInt32(uint position)
        {
            byte[] buffer = new byte[4];
            ReadBytes(position, buffer);

            var value = BitConverter.ToUInt32(buffer, 0);

            return value;
        }

        /// <summary>
        /// Reads a 64-bit unsigned integer from the backup memory.
        /// </summary>
        /// <param name="position">Position on the backup memory to read from.</param>
        /// <returns>The value.</returns>
        public static ulong ReadUInt64(uint position)
        {
            byte[] buffer = new byte[8];
            ReadBytes(position, buffer);

            var value = BitConverter.ToUInt64(buffer, 0);

            return value;
        }

        #endregion


        #region native methods calls

        /// <summary>
        /// Reads an array of byte values from the backup memory.
        /// </summary>
        /// <param name="position">Position on the backup memory to read from.</param>
        /// <param name="value">The array of values.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void ReadBytes(uint position, byte[] value);

        /// <summary>
        /// Writes an array of byte values to the backup memory.
        /// </summary>
        /// <param name="position">Position on the backup memory to write the <paramref name="value"/>.</param>
        /// <param name="value">The value to write.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern static void WriteBytes(uint position, byte[] value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern int GetSize();

        #endregion

    }
}
