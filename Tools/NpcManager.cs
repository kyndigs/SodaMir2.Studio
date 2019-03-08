using SodaMir2.ImageLibrary;
using SodaMir2.Studio.Component;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SodaMir2.Studio.Tools
{
    public partial class NpcManager : Form
    {
        // private List<NpcRecord> _npcList { get; set; }

        public NpcManager()
        {
            InitializeComponent();
        }

        private void NpcManager_Load(object sender, EventArgs e)
        {
            //ResourceDatabase.Initialize();
            //SodaImageManager.Initialize(@"D:\Development\Mir2 Clients\SodaMirClient\Data");

            //_npcList = ResourceDatabase.LoadNpcs();

            //foreach (var npc in _npcList)
            //{
            //    lstNpcList.Items.Add(npc.NpcName);
            //}

            //lblNpcCount.Text = _npcList.Count().ToString();
            //lstNpcList.SelectedIndex = 0;
        }

        private void LstNpcList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var npc = _npcList[lstNpcList.SelectedIndex];
            //var offset = GetNpcOffset(npc.Body);

            //try
            //{
            //    propertyGrid1.SelectedObject = npc;
            //    picNpcPreview.Image = SodaImageManager.NpcImg.GetCachedBitmapImage(offset);
            //}
            //catch (Exception)
            //{
            //    return;
            //}
        }

        #region Offset Functions

        public static int GetNpcOffset(int appr)
        {
            switch (appr)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                    return 60 * appr;
                case 23:
                    return 1380;
                case 24:
                    return 1500;
                case 25:
                    return 1560;
                case 26:
                    return 1620;
                case 27:
                    return 1680;
                case 28:
                    return 1740;
                case 29:
                    return 1800;
                case 30:
                    return 1860;
                case 31:
                    return 1920;
                case 32:
                    return 1980;
                case 33:
                    return 2040;
                case 34:
                    return 2100;
                case 35:
                case 36:
                case 37:
                case 38:
                case 39:
                case 40:
                case 41:
                    return 1620 + 60 * (appr - 26);
                case 42:
                case 43:
                    return 2580;
                case 44:
                case 45:
                case 46:
                case 47:
                    return 2640;
                case 48:
                case 49:
                case 50:
                    return 2700 + 60 * (appr - 48);
                case 51:
                    return 2880;
                case 52:
                    return 2960;
                case 53:
                    return 3190;
                case 54:
                    return 3070;
                case 55: /* Skull Pile */
                    return 3130;
                case 56: /* Guard NPC */
                    return 3190;
                case 57: /* Liquid Stuff */
                    return 3250;
                case 58: /* Lion Statue */
                    return 3270;
                case 59: /* Fox Statue */
                    return 3290;
                case 60:
                    return 3330;
                case 61:
                case 62:
                case 63:
                case 64: /* Blue Smoke */
                    return 3350;
                case 65: /* Flame */
                    return 3430;
                case 66: /* Christmas Tree */
                    return 3450;
                case 67:
                    return 3500;
                case 68:
                    return 3570;
                case 69:
                    return 3610;
                case 70:
                    return 3630;
                case 71:
                    return 3650;
                case 72:
                    return 3670;
                case 73:
                    return 3690;
                case 74:
                    return 3710;
                case 75:
                    return 3730;
                case 76:
                    return 3770;
                case 77:
                    return 3810;
                case 78:
                    return 3850;
                case 79:
                    return 3870;
                case 80:
                    return 3890;
                case 81:
                    return 3910;
                case 82:
                    return 4070;
                case 83:
                    return 4070;
                case 84: /* Red Guy */
                    return 4070;
                case 85: /* Pillar */
                    return 4110;
                case 86: /* Pillar */
                    return 4130;
                case 87: /* White Fox */
                    return 4150;
                case 88: /* Prajna Stone */
                    return 4220;
                case 89: /* Prajna Stone */
                    return 4250;
                case 90: /* Green Ghost */
                    return 4280;
                case 91: /* Blue Ghost */
                    return 4350;
                case 92: /* Ambassador */
                    return 4373;
                case 93: /* ?? */
                    return 4460;
                case 94: /* Flame Statue */
                    return 4530;
                case 95: /* Flame Statue */
                    return 4569;
                case 96: /* Blue Orb */
                    return 4590;
                case 97: /* Skull Portal */
                    return 4610;
                case 98: /* Skull Portal */
                    return 4630;
                case 99: /* Guard NPC */
                    return 4650;
                case 100: /* Samurai NPC */
                    return 4690;
                case 101:
                    return 4730;
                case 102:
                    return 4770;

                case 103:
                    return 4810;
                case 104:
                    return 4850;
                case 105: /* Stone Statue */
                    return 4890;
                case 106: /* Stone Statue */
                    return 4910;
                case 107: /* Stone Statue */
                    return 4930;
                case 108: /* Stone Statue */
                    return 4950;
                case 109: /* Oma */
                    return 4970;
                case 110: /* Oma Warrior */
                    return 5010;

                case 111: /* Tombstone */
                    return 5050;
                case 112: /* Assassin Male */
                    return 5070;
                case 113: /* Assassin Female */
                    return 5110;
                case 114: /* Desk */
                    return 5150;
                case 115: /* Book Shelf */
                    return 5170;
                case 116: /* Book Shelf */
                    return 5190;
                case 117: /* Drawers */
                    return 5210;
                case 118: /* Drawers */
                    return 5230;
                case 119: /* Deva */
                    return 5250;
                case 120: /* Shinsu */
                    return 5290;
                case 121: /* Big Wolf */
                    return 5330;
                case 122: /* Tree */
                    return 5370;
                case 123: /* Orb */
                    return 5390;
                case 124: /* White Tiger */
                    return 5410;
                case 125: /* Santa */
                    return 5450;
                case 126: /* Spider */
                    return 5490;
                case 127: /* Archer NPC */
                    return 5530;
                case 128: /* Ogre */
                    return 5570;
                case 129: /* Sword NPC */
                    return 5610;
                case 130: /* Sword NPC */
                    return 5640;

                // 5680

                case 131: /* Gold Male Warr */
                    return 5790;

                // 5750 FLAG
                // 5770 CHEST

                case 132: /* Gold Female Warr */
                    return 5810;
                case 133: /* Gold Male Wizz */
                    return 5830;
                case 134: /* Gold Female Wizz */
                    return 5850;
                case 135: /* Gold Male Tao */
                    return 5870;
                case 136: /* Gold Female Tao */
                    return 5890;
                case 137: /* Gold Male Ass */
                    return 5910;
                case 138: /* Gold Female Ass */
                    return 5930;
                case 139: /* Gold Male */
                    return 5950;
                case 140: /* Gold Female */
                    return 5970;
                case 141: /* Gold Male */
                    return 5990;
                case 142: /* Gold Female */
                    return 6010;
                case 143: /* Gold Male */
                    return 6030;
                case 144: /* Gold Female */
                    return 6050;
                case 145: /* Gold Male */
                    return 6070;
                case 146: /* Gold Female */
                    return 6090;
                case 147: /* Santa */
                    return 6120;
                case 148: /* Rudolph */
                    return 6150;
                case 149: /* Evil Snowman */
                    return 6190;
                case 150: /* Cat Statue */
                    return 6230;
                case 151: /* Cat Statue */
                    return 6250;
                case 152: /* Cat Statue */
                    return 6270;
                case 153: /* Cat Statue */
                    return 6290;
                case 154: /* Cat Statue */
                    return 6310;
                case 155: /* Cat Statue */
                    return 6330;
                case 156: /* Cat Statue */
                    return 6350;
                case 157: /* Bookshelf */
                    return 6370;
                case 158:
                    return 6390;
                case 159:
                    return 6430;
                case 160: /* Flag */
                    return 6470;
                case 161: /* Flag */
                    return 6490;
                case 162: /* Torch */
                    return 6510;
                case 163: /* Dragon Bowl */
                    return 6540;
                case 164: /* Dragon Statue */
                    return 6560;
                case 165: /* Flag */
                    return 6580;
                case 166: /* Chief NPC */
                    return 6600;
                case 167: /* Chief NPC */
                    return 6620;
                case 168: /* Flag */
                    return 6690;
                case 169: /* Flag */
                    return 6710;
                case 170: /* Warrior NPC */
                    return 6730;
                case 171: /* Flag */
                    return 6770;
                case 172: /* Flag */
                    return 6800;
                case 173: /* Flag */
                    return 6830;
                case 174: /* Flag */
                    return 6860;
                case 175: /* Flag */
                    return 6890;
                case 176: /* Flag */
                    return 6920;
                case 177: /* Flag */
                    return 6950;
                case 178: /* Flag */
                    return 6980;
                case 179: /* Flag */
                    return 7010;
                case 180: /* Flag */
                    return 7040;
                case 181: /* Rabbit */
                    return 7070;
                case 182: /* Flag */
                    return 7110;
                case 183: /* Flag */
                    return 7130;
                case 184: /* Warrior */
                    return 7150;
                case 185: /* Fat */
                    return 7190;
                case 186: /* Woman */
                    return 7230;
                case 187: /* Woman */
                    return 7270;
                case 188: /* Monk */
                    return 7310;
                case 189: /* Scroll Guy */
                    return 7350;
                case 190: /* Woman */
                    return 7420;
                case 191: /* Old Man */
                    return 7490;
                case 192: /* Man NPC */
                    return 7530;
                case 193: /* Archer NPC */
                    return 7570;
                case 194: /* Archer NPC */
                    return 7610;
                case 195: /* Archer NPC */
                    return 7650;
                case 196: /* Archer NPC */
                    return 7690;
                case 197: /* Archer NPC */
                    return 7730;
                case 198: /* Archer NPC */
                    return 7770;
                case 199: /* Tree */
                    return 7810;
                case 200: /* Flag */
                    return 7850;
                case 201: /* Flag */
                    return 7870;
                case 202: /* Big Warr */
                    return 7890;
                case 203: /* Berzerker */
                    return 7960;
                case 204: /* Shaman */
                    return 8030;
                case 205: /* Wall */
                    return 8100;
                case 206: /* Wall */
                    return 8110;
                default:
                    return 1470 + 60 * (appr - 24);
            }
        }

        #endregion
    }
}
