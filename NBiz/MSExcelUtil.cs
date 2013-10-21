using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NBiz
{
  
/**
 * the units converter for excel 
 * @author xio[darjino@hotmail.com]
 *
 */
public class MSExcelUtil {
 
 public static readonly short EXCEL_COLUMN_WIDTH_FACTOR = 256;
 public static readonly int UNIT_OFFSET_LENGTH = 7;
 public static readonly   int[] UNIT_OFFSET_MAP = new int[] { 0, 36, 73, 109, 146, 182, 219 };
 
 /**
  * pixel units to excel width units(units of 1/256th of a character width)
  * @param pxs
  * @return
  */
 public static short pixel2WidthUnits(int pxs) {
   short widthUnits = (short) (EXCEL_COLUMN_WIDTH_FACTOR * (pxs / UNIT_OFFSET_LENGTH));

   widthUnits += (short)UNIT_OFFSET_MAP[(pxs % UNIT_OFFSET_LENGTH)];

   return widthUnits;
 }
 
 /**
  * excel width units(units of 1/256th of a character width) to pixel units 
  * @param widthUnits
  * @return
  */
 public static int widthUnits2Pixel(short widthUnits) {
   int pixels = (widthUnits / EXCEL_COLUMN_WIDTH_FACTOR) * UNIT_OFFSET_LENGTH;
 
   int offsetWidthUnits = widthUnits % EXCEL_COLUMN_WIDTH_FACTOR;
   pixels +=(int) Math.Round((float)offsetWidthUnits / ((float) EXCEL_COLUMN_WIDTH_FACTOR / UNIT_OFFSET_LENGTH));
 
   return pixels;
 }
 
}
}
