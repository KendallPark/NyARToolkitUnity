/* 
 * PROJECT: NyARToolkitCS(Extension)
 * -------------------------------------------------------------------------------
 * The NyARToolkitCS is Java edition ARToolKit class library.
 * Copyright (C)2008-2012 Ryo Iizuka
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 * 
 * For further information please contact.
 *	http://nyatla.jp/nyatoolkit/
 *	<airmail(at)ebony.plala.or.jp> or <nyatla(at)nyatla.jp>
 * 
 */
using System;
using System.Diagnostics;
namespace jp.nyatla.nyartoolkit.cs.core
{
    /**
     * このクラスは、RGBラスタクラスの基本処理を実装します。
     */
    public abstract class NyARRgbRaster_BasicClass : INyARRgbRaster
    {
        /** ラスタのサイズを格納します。*/
        protected NyARIntSize _size;
        protected int _buffer_type;
        /**
         * コンストラクタです。
         * @param i_width
         * ラスタの幅に設定する値
         * @param i_height
         * ラスタの高さに設定する値
         * @param i_buffer_type
         * バッファタイプ値に設定する値
         */
        protected NyARRgbRaster_BasicClass(int i_width, int i_height, int i_buffer_type)
        {
            this._size = new NyARIntSize(i_width, i_height);
            this._buffer_type = i_buffer_type;
        }
        /**
         * この関数は、ラスタの幅を返します。
         */
        public int getWidth()
        {
            return this._size.w;
        }
        /**
         * この関数は、ラスタの高さを返します。
         */
        public int getHeight()
        {
            return this._size.h;
        }
        /**
         * この関数は、ラスタのサイズを格納したオブジェクトを返します。
         */
        public NyARIntSize getSize()
        {
            return this._size;
        }
        /**
         * この関数は、ラスタのバッファへの参照値を返します。
         * バッファの形式は、コンストラクタに指定した形式と同じです。
         */
        public int getBufferType()
        {
            return _buffer_type;
        }
        /**
         * この関数は、ラスタの幅を返します。
         */
        public bool isEqualBufferType(int i_type_value)
        {
            return this._buffer_type == i_type_value;
        }
        /**
         * ラスタのコピーを実行します。
         * この関数は暫定です。低速なので注意してください。
         * @param i_input
         * @param o_output
         * @ 
         */
        public static void copy(INyARRgbRaster i_input, INyARRgbRaster o_output)
        {
            Debug.Assert(i_input.getSize().isEqualSize(o_output.getSize()));
            int width = i_input.getWidth();
            int height = i_input.getHeight();
            int[] rgb = new int[3];
            INyARRgbPixelDriver inr = i_input.getRgbPixelDriver();
            INyARRgbPixelDriver outr = o_output.getRgbPixelDriver();
            for (int i = height - 1; i >= 0; i--)
            {
                for (int i2 = width - 1; i2 >= 0; i2--)
                {
                    inr.getPixel(i2, i, rgb);
                    outr.setPixel(i2, i, rgb);
                }
            }
        }
        public abstract bool hasBuffer();
        public abstract INyARRgbPixelDriver getRgbPixelDriver();
        public abstract void wrapBuffer(object i_ref_buf);
        public abstract object createInterface(Type i_iid);
        public abstract object getBuffer();
    }
}