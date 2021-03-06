﻿using George_Dermentzis_Assignment_4.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace George_Dermentzis_Assignment_4
{
    class MyDatabase
    {
        public List<TShirt> TShirts { get; set; } = new List<TShirt>();
        public MyDatabase()
        {
            TShirt s1 = new TShirt(Color.GREEN, Size.L, Fabric.CASHMERE);
            TShirt s2 = new TShirt(Color.BLUE, Size.M, Fabric.COTTON);
            TShirt s3 = new TShirt(Color.RED, Size.S, Fabric.LINEN);
            TShirt s4 = new TShirt(Color.ORANGE, Size.M, Fabric.SILK);
            TShirt s5 = new TShirt(Color.GREEN, Size.XS, Fabric.WOOL);
            TShirt s6 = new TShirt(Color.VIOLET, Size.M, Fabric.CASHMERE);
            TShirt s7 = new TShirt(Color.GREEN, Size.L, Fabric.COTTON);
            TShirt s8 = new TShirt(Color.BLUE, Size.S, Fabric.LINEN);
            TShirt s9 = new TShirt(Color.BLUE, Size.M, Fabric.CASHMERE);
            TShirt s10 = new TShirt(Color.RED, Size.L, Fabric.WOOL);
            TShirt s11 = new TShirt(Color.RED, Size.M, Fabric.RAYON);
            TShirt s12 = new TShirt(Color.BLUE, Size.L, Fabric.CASHMERE);
            TShirt s13 = new TShirt(Color.INDIGO, Size.L, Fabric.COTTON);
            TShirt s14 = new TShirt(Color.RED, Size.S, Fabric.LINEN);
            TShirt s15 = new TShirt(Color.ORANGE, Size.S, Fabric.SILK);
            TShirt s16 = new TShirt(Color.VIOLET, Size.M, Fabric.CASHMERE);
            TShirt s17 = new TShirt(Color.RED, Size.XS, Fabric.LINEN);
            TShirt s18 = new TShirt(Color.BLUE, Size.XS, Fabric.POLYESTER);
            TShirt s19 = new TShirt(Color.RED, Size.L, Fabric.POLYESTER);
            TShirt s20 = new TShirt(Color.BLUE, Size.L, Fabric.CASHMERE);
            TShirt s21 = new TShirt(Color.GREEN, Size.L, Fabric.CASHMERE);
            TShirt s22 = new TShirt(Color.INDIGO, Size.M, Fabric.COTTON);
            TShirt s23 = new TShirt(Color.RED, Size.S, Fabric.RAYON);
            TShirt s24 = new TShirt(Color.VIOLET, Size.M, Fabric.POLYESTER);
            TShirt s25 = new TShirt(Color.GREEN, Size.XS, Fabric.COTTON);
            TShirt s26 = new TShirt(Color.YELLOW, Size.M, Fabric.CASHMERE);
            TShirt s27 = new TShirt(Color.GREEN, Size.L, Fabric.COTTON);
            TShirt s28 = new TShirt(Color.BLUE, Size.S, Fabric.LINEN);
            TShirt s29 = new TShirt(Color.YELLOW, Size.M, Fabric.CASHMERE);
            TShirt s30 = new TShirt(Color.ORANGE, Size.L, Fabric.SILK);
            TShirt s31 = new TShirt(Color.RED, Size.M, Fabric.RAYON);
            TShirt s32 = new TShirt(Color.BLUE, Size.L, Fabric.RAYON);
            TShirt s33 = new TShirt(Color.INDIGO, Size.L, Fabric.COTTON);
            TShirt s34 = new TShirt(Color.RED, Size.S, Fabric.LINEN);
            TShirt s35 = new TShirt(Color.VIOLET, Size.S, Fabric.COTTON);
            TShirt s36 = new TShirt(Color.BLUE, Size.M, Fabric.SILK);
            TShirt s37 = new TShirt(Color.YELLOW, Size.XS, Fabric.LINEN);
            TShirt s38 = new TShirt(Color.BLUE, Size.XS, Fabric.POLYESTER);
            TShirt s39 = new TShirt(Color.RED, Size.L, Fabric.POLYESTER);
            TShirt s40 = new TShirt(Color.BLUE, Size.L, Fabric.WOOL);
            TShirt s41 = new TShirt(Color.GREEN, Size.L, Fabric.CASHMERE);
            TShirt s42 = new TShirt(Color.BLUE, Size.M, Fabric.COTTON);
            TShirt s43 = new TShirt(Color.RED, Size.S, Fabric.LINEN);
            TShirt s44 = new TShirt(Color.ORANGE, Size.M, Fabric.SILK);
            TShirt s45 = new TShirt(Color.GREEN, Size.XS, Fabric.WOOL);
            TShirt s46 = new TShirt(Color.VIOLET, Size.M, Fabric.CASHMERE);
            TShirt s47 = new TShirt(Color.GREEN, Size.L, Fabric.COTTON);
            TShirt s48 = new TShirt(Color.BLUE, Size.S, Fabric.LINEN);
            TShirt s49 = new TShirt(Color.BLUE, Size.M, Fabric.CASHMERE);
            TShirt s50 = new TShirt(Color.RED, Size.L, Fabric.WOOL);
            TShirt s51 = new TShirt(Color.RED, Size.M, Fabric.RAYON);
            TShirt s52 = new TShirt(Color.BLUE, Size.L, Fabric.CASHMERE);
            TShirt s53 = new TShirt(Color.INDIGO, Size.L, Fabric.COTTON);
            TShirt s54 = new TShirt(Color.RED, Size.S, Fabric.LINEN);
            TShirt s55 = new TShirt(Color.ORANGE, Size.S, Fabric.SILK);
            TShirt s56 = new TShirt(Color.VIOLET, Size.M, Fabric.CASHMERE);
            TShirt s57 = new TShirt(Color.RED, Size.XS, Fabric.LINEN);
            TShirt s58 = new TShirt(Color.BLUE, Size.XS, Fabric.POLYESTER);
            TShirt s59 = new TShirt(Color.RED, Size.L, Fabric.POLYESTER);
            TShirt s60 = new TShirt(Color.BLUE, Size.L, Fabric.CASHMERE);
            TShirt s61 = new TShirt(Color.GREEN, Size.L, Fabric.CASHMERE);
            TShirt s62 = new TShirt(Color.INDIGO, Size.M, Fabric.COTTON);
            TShirt s63 = new TShirt(Color.RED, Size.S, Fabric.RAYON);
            TShirt s64 = new TShirt(Color.VIOLET, Size.M, Fabric.POLYESTER);
            TShirt s65 = new TShirt(Color.GREEN, Size.XS, Fabric.COTTON);
            TShirt s66 = new TShirt(Color.YELLOW, Size.M, Fabric.CASHMERE);
            TShirt s67 = new TShirt(Color.GREEN, Size.L, Fabric.COTTON);
            TShirt s68 = new TShirt(Color.BLUE, Size.S, Fabric.LINEN);
            TShirt s69 = new TShirt(Color.YELLOW, Size.M, Fabric.CASHMERE);
            TShirt s70 = new TShirt(Color.ORANGE, Size.L, Fabric.SILK);
            TShirt s71 = new TShirt(Color.RED, Size.M, Fabric.RAYON);
            TShirt s72 = new TShirt(Color.BLUE, Size.L, Fabric.RAYON);
            TShirt s73 = new TShirt(Color.INDIGO, Size.L, Fabric.COTTON);
            TShirt s74 = new TShirt(Color.RED, Size.S, Fabric.LINEN);
            TShirt s75 = new TShirt(Color.VIOLET, Size.S, Fabric.COTTON);
            TShirt s76 = new TShirt(Color.BLUE, Size.M, Fabric.SILK);
            TShirt s77 = new TShirt(Color.YELLOW, Size.XS, Fabric.LINEN);
            TShirt s78 = new TShirt(Color.BLUE, Size.XS, Fabric.POLYESTER);
            TShirt s79 = new TShirt(Color.RED, Size.L, Fabric.POLYESTER);
            TShirt s80 = new TShirt(Color.BLUE, Size.L, Fabric.WOOL);

            TShirts.Add(s1);
            TShirts.Add(s2);
            TShirts.Add(s3);
            TShirts.Add(s4);
            TShirts.Add(s5);
            TShirts.Add(s6);
            TShirts.Add(s7);
            TShirts.Add(s8);
            TShirts.Add(s9);
            TShirts.Add(s10);
            TShirts.Add(s11);
            TShirts.Add(s12);
            TShirts.Add(s13);
            TShirts.Add(s14);
            TShirts.Add(s15);
            TShirts.Add(s16);
            TShirts.Add(s17);
            TShirts.Add(s18);
            TShirts.Add(s19);
            TShirts.Add(s20);
            TShirts.Add(s21);
            TShirts.Add(s22);
            TShirts.Add(s23);
            TShirts.Add(s24);
            TShirts.Add(s25);
            TShirts.Add(s26);
            TShirts.Add(s27);
            TShirts.Add(s28);
            TShirts.Add(s29);
            TShirts.Add(s30);
            TShirts.Add(s31);
            TShirts.Add(s32);
            TShirts.Add(s33);
            TShirts.Add(s34);
            TShirts.Add(s35);
            TShirts.Add(s36);
            TShirts.Add(s37);
            TShirts.Add(s38);
            TShirts.Add(s39);
            TShirts.Add(s40);
            TShirts.Add(s41);
            TShirts.Add(s42);
            TShirts.Add(s43);
            TShirts.Add(s44);
            TShirts.Add(s45);
            TShirts.Add(s46);
            TShirts.Add(s47);
            TShirts.Add(s48);
            TShirts.Add(s49);
            TShirts.Add(s50);
            TShirts.Add(s51);
            TShirts.Add(s52);
            TShirts.Add(s53);
            TShirts.Add(s54);
            TShirts.Add(s55);
            TShirts.Add(s56);
            TShirts.Add(s57);
            TShirts.Add(s58);
            TShirts.Add(s59);
            TShirts.Add(s60);
            TShirts.Add(s61);
            TShirts.Add(s62);
            TShirts.Add(s63);
            TShirts.Add(s64);
            TShirts.Add(s65);
            TShirts.Add(s66);
            TShirts.Add(s67);
            TShirts.Add(s68);
            TShirts.Add(s69);
            TShirts.Add(s70);
            TShirts.Add(s71);
            TShirts.Add(s72);
            TShirts.Add(s73);
            TShirts.Add(s74);
            TShirts.Add(s75);
            TShirts.Add(s76);
            TShirts.Add(s77);
            TShirts.Add(s78);
            TShirts.Add(s79);
            TShirts.Add(s80);
        }
    }
}
