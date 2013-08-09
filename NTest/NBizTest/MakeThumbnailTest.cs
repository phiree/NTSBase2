﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
namespace NTest.NBizTest
{
    public class MakeThumbnailTest
    {
        NBiz.ThumbnailMaker maker = new NBiz.ThumbnailMaker();
        public void MakeTest()
        {
            NBiz.ThumbnailMaker.Make(@"E:\workspace\code\NTSBase\NTest\TestFiles\NBizTest\MakeThumbnail\original\"
               ,@"E:\workspace\code\NTSBase\NTest\TestFiles\NBizTest\MakeThumbnail\Thumbnail\"
               , "GIMS-110-BC-2.jpg", 100, 100, NBiz.ThumbnailType.GeometricScalingByWidth);

            Assert.IsTrue(System.IO.File.Exists(@"E:\workspace\code\NTSBase\NTest\TestFiles\NBizTest\MakeThumbnail\thumbnail\100_100\GIMS-110-BC-2_100-100.jpg"));
        }
        public void MakeTestWithWhiteSpaceInName()
        {

            string basename = "IM-240DNE + B-801SA";
            NBiz.ThumbnailMaker.Make(Environment.CurrentDirectory + @"\TestFiles\NBizTest\MakeThumbnail\original\"
               , Environment.CurrentDirectory + @"\TestFiles\NBizTest\MakeThumbnail\Thumbnail\"
               , basename+".jpg", 100, 100, NBiz.ThumbnailType.GeometricScalingByWidth);

            Assert.IsTrue(System.IO.File.Exists(Environment.CurrentDirectory + @"\TestFiles\NBizTest\MakeThumbnail\thumbnail\100_100\" + basename + "_100-100.jpg"));
        }
    }
}
