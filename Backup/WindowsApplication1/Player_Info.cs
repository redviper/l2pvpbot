using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace l2pvp
{
    public class Player_Info
    {

        private readonly object AbnormalEffectsLock;
        private readonly object AccessLevelLock;
        private readonly object AccuracyLock;
        private readonly object ActiveLock;
        private readonly object AllyCrestIDLock;
        private readonly object AllyIDLock;
        private readonly object AttackSpeedMultLock;
        private readonly object botstateLock;
        private readonly object buffskillLock;
        private readonly object bufftargetLock;
        private readonly object charIDLock;
        private readonly object ClanCrestIDLargeLock;
        private readonly object ClanCrestIDLock;
        private readonly object ClanIDLock;
        private readonly object ClanPrivilegesLock;
        private readonly object ClassLock;
        private readonly object CollisionHeightLock;
        private readonly object CollisionRadiusLock;
        private readonly object CONLock;
        private readonly object CubicCountLock;
        private readonly object CubicsLock;
        private readonly object Cur_LoadLock;
        private readonly object CurCPLock;
        private readonly object CurHPLock;
        private readonly object CurMPLock;
        private readonly object DemonSwordLock;
        private readonly object DestXLock;
        private readonly object DestYLock;
        private readonly object DestZLock;
        private readonly object DEXLock;
        private readonly object EnchantAmountLock;
        private readonly object EvasionLock;
        private readonly object FaceLock;
        private readonly object FindPartyLock;
        private readonly object FishXLock;
        private readonly object FishYLock;
        private readonly object FishZLock;
        private readonly object flRunSpeedLock;
        private readonly object flWalkSpeedLock;
        private readonly object FlyRunSpeedLock;
        private readonly object FlyWalkSpeedLock;
        private readonly object FocusLock;
        private readonly object Got_SkillsLock;
        private readonly object HairColorLock;
        private readonly object HairSytleLock;
        private readonly object hasDwarfCraftLock;
        private readonly object HeadingLock;
        private readonly object HeroGlowLock;
        private readonly object HeroIconLock;
        private readonly object INTLock;
        private readonly object InventoryLimitLock;
        private readonly object isClanLeaderLock;
        private readonly object isFishingLock;
        private readonly object isRunningLock;
        private readonly object itm_BackLock;
        private readonly object itm_ChestLock;
        private readonly object itm_FaceLock;
        private readonly object itm_FeetLock;
        private readonly object itm_GlovesLock;
        private readonly object itm_HairLock;
        private readonly object itm_HeadLock;
        private readonly object itm_LEarLock;
        private readonly object itm_LegsLock;
        private readonly object itm_LFingerLock;
        private readonly object itm_LHandLock;
        private readonly object itm_LRHandLock;
        private readonly object itm_NeckLock;
        private readonly object itm_REarLock;
        private readonly object itm_RFingerLock;
        private readonly object itm_RHandLock;
        private readonly object itm_UnderLock;
        private readonly object KarmaLock;
        private readonly object last_MAPXLock;
        private readonly object last_MAPYLock;
        private readonly object lastbufftimeLock;
        private readonly object lastMoveTimeLock;
        private readonly object lastVerifyTimeLock;
        private readonly object LevelLock;
        private readonly object MatkLock;
        private readonly object MatkSpeedLock;
        private readonly object Max_LoadLock;
        private readonly object MaxCPLock;
        private readonly object MaxHPLock;
        private readonly object MaxMPLock;
        private readonly object MaxTatsLock;
        private readonly object MDefLock;
        private readonly object MENLock;
        private readonly object MountTypeLock;
        private readonly object moveLock;
        private readonly object MoveSpeedMultLock;
        private readonly object MoveTargetLock;
        private readonly object MoveTargetTypeLock;
        private readonly object mybuffsLock;
        private readonly object myskillsLock;
        private readonly object NameColorLock;
        private readonly object NameLock;
        private readonly object obj_BackLock;
        private readonly object obj_ChestLock;
        private readonly object obj_FaceLock;
        private readonly object obj_FeetLock;
        private readonly object obj_GlovesLock;
        private readonly object obj_HairLock;
        private readonly object obj_HeadLock;
        private readonly object obj_LEarLock;
        private readonly object obj_LegsLock;
        private readonly object obj_LFingerLock;
        private readonly object obj_LHandLock;
        private readonly object obj_LRHandLock;
        private readonly object obj_NeckLock;
        private readonly object obj_REarLock;
        private readonly object obj_RFingerLock;
        private readonly object obj_RHandLock;
        private readonly object obj_UnderLock;
        private readonly object ObjIDLock;
        private readonly object PartyCountLock;
        private readonly object PartyLeaderLock;
        private readonly object PartyLootLock;
        private readonly object PartyMembersLock;
        private readonly object PatkLock;
        private readonly object PatkSpeedLock;
        private readonly object PDefLock;
        private readonly object PKCountLock;
        private readonly object PledgeClassLock;
        private readonly object PrivateStoreTypeLock;
        private readonly object PvPCountLock;
        private readonly object PvPFlagLock;
        private readonly object RaceLock;
        private readonly object RecAmountLock;
        private readonly object RecLeftLock;
        private readonly object RunSpeedLock;
        private readonly object sessionIDLock;
        private readonly object SexLock;
        private readonly object SpecialEffectsLock;
        private readonly object SPLock;
        private readonly object STRLock;
        private readonly object SwimRunSpeedLock;
        private readonly object SwimWalkSpeedLock;
        private readonly object Symbol1Lock;
        private readonly object Symbol2Lock;
        private readonly object Symbol3Lock;
        private readonly object TargetColorLock;
        private readonly object targetidLock;
        private readonly object targetspoiledLock;
        private readonly object targettypeLock;
        private readonly object TeamCircleLock;
        private readonly object TitleColorLock;
        private readonly object TitleLock;
        private readonly object WalkSpeedLock;
        private readonly object WITLock;
        private readonly object XLock;
        private readonly object XPLock;
        private readonly object xxx2Lock;
        private readonly object xxx3Lock;
        private readonly object xxxLock;
        private readonly object YLock;
        private readonly object ZLock;

        private uint _AbnormalEffects;
        private uint _AccessLevel;
        private uint _Accuracy;
        private uint _Active;
        private uint _AllyCrestID;
        private uint _AllyID;
        private double _AttackSpeedMult;
        private int _BOT_STATE;
        private uint _BuffSkill;
        private uint _BuffTarget;
        private uint _charID;
        private uint _ClanCrestID;
        private uint _ClanCrestIDLarge;
        private uint _ClanID;
        private ulong _ClanPrivileges;
        private uint _Class;
        private double _CollisionHeight;
        private double _CollisionRadius;
        private uint _CON;
        private ushort _CubicCount;
        private ArrayList _Cubics;
        private double _Cur_CP;
        private double _Cur_HP;
        private uint _Cur_Load;
        private double _Cur_MP;
        private uint _DemonSword;
        private int _Dest_X;
        private int _Dest_Y;
        private int _Dest_Z;
        private uint _DEX;
        private byte _EnchantAmount;
        private uint _Evasion;
        private uint _Face;
        private byte _FindParty;
        private int _FishX;
        private int _FishY;
        private int _FishZ;
        private uint _flRunSpeed;
        private uint _flWalkSpeed;
        private uint _FlyRunSpeed;
        private uint _FlyWalkSpeed;
        private uint _Focus;
        private bool _Got_Skills;
        private uint _HairColor;
        private uint _HairSytle;
        private byte _hasDwarfCraft;
        private int _Heading;
        private byte _HeroGlow;
        private byte _HeroIcon;
        private uint _INT;
        private ushort _InventoryLimit;
        private uint _isClanLeader;
        private byte _isFishing;
        private uint _isRunning;
        private uint _itm_Back;
        private uint _itm_Chest;
        private uint _itm_Face;
        private uint _itm_Feet;
        private uint _itm_Gloves;
        private uint _itm_Hair;
        private uint _itm_Head;
        private uint _itm_LEar;
        private uint _itm_Legs;
        private uint _itm_LFinger;
        private uint _itm_LHand;
        private uint _itm_LRHand;
        private uint _itm_Neck;
        private uint _itm_REar;
        private uint _itm_RFinger;
        private uint _itm_RHand;
        private uint _itm_Under;
        private uint _Karma;
        private int _last_MAPX;
        private int _last_MAPY;
        private DateTime _lastbufftime;
        private DateTime _lastMoveTime;
        private DateTime _lastVerifyTime;
        private uint _Level;
        private uint _Matk;
        private uint _MatkSpeed;
        private double _Max_CP;
        private double _Max_HP;
        private uint _Max_Load;
        private double _Max_MP;
        private uint _MaxTats;
        private uint _MDef;
        private uint _MEN;
        private byte _MountType;
        private double _MoveSpeedMult;
        private uint _MoveTarget;
        private int _MoveTargetType;
        private bool _Moving;
        private ArrayList _my_skills;
        private string _Name;
        private uint _NameColor;
        private uint _obj_Back;
        private uint _obj_Chest;
        private uint _obj_Face;
        private uint _obj_Feet;
        private uint _obj_Gloves;
        private uint _obj_Hair;
        private uint _obj_Head;
        private uint _obj_LEar;
        private uint _obj_Legs;
        private uint _obj_LFinger;
        private uint _obj_LHand;
        private uint _obj_LRHand;
        private uint _obj_Neck;
        private uint _obj_REar;
        private uint _obj_RFinger;
        private uint _obj_RHand;
        private uint _obj_Under;
        private uint _ObjID;
        private uint _PartyCount;
        private uint _PartyLeader;
        private uint _PartyLoot;
        private ArrayList _PartyMembers;
        private uint _Patk;
        private uint _PatkSpeed;
        private uint _PDef;
        private uint _PKCount;
        private uint _PledgeClass;
        private byte _PrivateStoreType;
        private uint _PvPCount;
        private uint _PvPFlag;
        private uint _Race;
        private ushort _RecAmount;
        private ushort _RecLeft;
        private uint _RunSpeed;
        private byte[] _sessionID;
        private uint _Sex;
        private uint _SP;
        private uint _SpecialEffects;
        private uint _STR;
        private uint _SwimRunSpeed;
        private uint _SwimWalkSpeed;
        private uint _Symbol1;
        private uint _Symbol2;
        private uint _Symbol3;
        private ushort _TargetColor;
        private uint _TargetID;
        private bool _TargetSpoiled;
        private int _TargetType;
        private byte _TeamCircle;
        private string _Title;
        private uint _TitleColor;
        private uint _WalkSpeed;
        private uint _WIT;
        private int _X;
        private ulong _XP;
        private uint _xxx;
        private uint _xxx2;
        private uint _xxx3;
        private int _Y;
        private int _Z;

        public uint AbnormalEffects
        {
            get
            {
                uint ui;

                lock (AbnormalEffectsLock)
                {
                    ui = _AbnormalEffects;
                }
                return ui;
            }
            set
            {
                lock (AbnormalEffectsLock)
                {
                    _AbnormalEffects = value;
                }
            }
        }

        public uint AccessLevel
        {
            get
            {
                uint ui;

                lock (AccessLevelLock)
                {
                    ui = _AccessLevel;
                }
                return ui;
            }
            set
            {
                lock (AccessLevelLock)
                {
                    _AccessLevel = value;
                }
            }
        }

        public uint Accuracy
        {
            get
            {
                uint ui;

                lock (AccuracyLock)
                {
                    ui = _Accuracy;
                }
                return ui;
            }
            set
            {
                lock (AccuracyLock)
                {
                    _Accuracy = value;
                }
            }
        }

        public uint Active
        {
            get
            {
                uint ui;

                lock (ActiveLock)
                {
                    ui = _Active;
                }
                return ui;
            }
            set
            {
                lock (ActiveLock)
                {
                    _Active = value;
                }
            }
        }

        public uint AllyCrestID
        {
            get
            {
                uint ui;

                lock (AllyCrestIDLock)
                {
                    ui = _AllyCrestID;
                }
                return ui;
            }
            set
            {
                lock (AllyCrestIDLock)
                {
                    _AllyCrestID = value;
                }
            }
        }

        public uint AllyID
        {
            get
            {
                uint ui;

                lock (AllyIDLock)
                {
                    ui = _AllyID;
                }
                return ui;
            }
            set
            {
                lock (AllyIDLock)
                {
                    _AllyID = value;
                }
            }
        }

        public double AttackSpeedMult
        {
            get
            {
                double d;

                lock (AttackSpeedMultLock)
                {
                    d = _AttackSpeedMult;
                }
                return d;
            }
            set
            {
                lock (AttackSpeedMultLock)
                {
                    _AttackSpeedMult = value;
                }
            }
        }

        public int BOT_STATE
        {
            get
            {
                int i;

                lock (botstateLock)
                {
                    i = _BOT_STATE;
                }
                return i;
            }
            set
            {
                lock (botstateLock)
                {
                    _BOT_STATE = value;
                }
            }
        }

        public uint BuffSkill
        {
            get
            {
                uint ui;

                lock (buffskillLock)
                {
                    ui = _BuffSkill;
                }
                return ui;
            }
            set
            {
                lock (buffskillLock)
                {
                    _BuffSkill = value;
                }
            }
        }

        public uint BuffTarget
        {
            get
            {
                uint ui;

                lock (bufftargetLock)
                {
                    ui = _BuffTarget;
                }
                return ui;
            }
            set
            {
                lock (bufftargetLock)
                {
                    _BuffTarget = value;
                }
            }
        }

        public uint charID
        {
            get
            {
                uint ui;

                lock (charIDLock)
                {
                    ui = _charID;
                }
                return ui;
            }
            set
            {
                lock (charIDLock)
                {
                    _charID = value;
                }
            }
        }

        public uint ClanCrestID
        {
            get
            {
                uint ui;

                lock (ClanCrestIDLock)
                {
                    ui = _ClanCrestID;
                }
                return ui;
            }
            set
            {
                lock (ClanCrestIDLock)
                {
                    _ClanCrestID = value;
                }
            }
        }

        public uint ClanCrestIDLarge
        {
            get
            {
                uint ui;

                lock (ClanCrestIDLargeLock)
                {
                    ui = _ClanCrestIDLarge;
                }
                return ui;
            }
            set
            {
                lock (ClanCrestIDLargeLock)
                {
                    _ClanCrestIDLarge = value;
                }
            }
        }

        public uint ClanID
        {
            get
            {
                uint ui;

                lock (ClanIDLock)
                {
                    ui = _ClanID;
                }
                return ui;
            }
            set
            {
                lock (ClanIDLock)
                {
                    _ClanID = value;
                }
            }
        }

        public ulong ClanPrivileges
        {
            get
            {
                ulong ul;

                lock (ClanPrivilegesLock)
                {
                    ul = _ClanPrivileges;
                }
                return ul;
            }
            set
            {
                lock (ClanPrivilegesLock)
                {
                    _ClanPrivileges = value;
                }
            }
        }

        public uint Class
        {
            get
            {
                uint ui;

                lock (ClassLock)
                {
                    ui = _Class;
                }
                return ui;
            }
            set
            {
                lock (ClassLock)
                {
                    _Class = value;
                }
            }
        }

        public double CollisionHeight
        {
            get
            {
                double d;

                lock (CollisionHeightLock)
                {
                    d = _CollisionHeight;
                }
                return d;
            }
            set
            {
                lock (CollisionHeightLock)
                {
                    _CollisionHeight = value;
                }
            }
        }

        public double CollisionRadius
        {
            get
            {
                double d;

                lock (CollisionRadiusLock)
                {
                    d = _CollisionRadius;
                }
                return d;
            }
            set
            {
                lock (CollisionRadiusLock)
                {
                    _CollisionRadius = value;
                }
            }
        }

        public uint CON
        {
            get
            {
                uint ui;

                lock (CONLock)
                {
                    ui = _CON;
                }
                return ui;
            }
            set
            {
                lock (CONLock)
                {
                    _CON = value;
                }
            }
        }

        public ushort CubicCount
        {
            get
            {
                ushort ush;

                lock (CubicCountLock)
                {
                    ush = _CubicCount;
                }
                return ush;
            }
            set
            {
                lock (CubicCountLock)
                {
                    _CubicCount = value;
                }
            }
        }

        public ArrayList Cubics
        {
            get
            {
                ArrayList arrayList;

                lock (CubicsLock)
                {
                    arrayList = _Cubics;
                }
                return arrayList;
            }
            set
            {
                lock (CubicsLock)
                {
                    _Cubics = value;
                }
            }
        }

        public double Cur_CP
        {
            get
            {
                double d;

                lock (CurCPLock)
                {
                    d = _Cur_CP;
                }
                return d;
            }
            set
            {
                lock (CurCPLock)
                {
                    _Cur_CP = value;
                }
            }
        }

        public double Cur_HP
        {
            get
            {
                double d;

                lock (CurHPLock)
                {
                    d = _Cur_HP;
                }
                return d;
            }
            set
            {
                lock (CurHPLock)
                {
                    _Cur_HP = value;
                }
            }
        }

        public uint Cur_Load
        {
            get
            {
                uint ui;

                lock (Cur_LoadLock)
                {
                    ui = _Cur_Load;
                }
                return ui;
            }
            set
            {
                lock (Cur_LoadLock)
                {
                    _Cur_Load = value;
                }
            }
        }

        public double Cur_MP
        {
            get
            {
                double d;

                lock (CurMPLock)
                {
                    d = _Cur_MP;
                }
                return d;
            }
            set
            {
                lock (CurMPLock)
                {
                    _Cur_MP = value;
                }
            }
        }

        public uint DemonSword
        {
            get
            {
                uint ui;

                lock (DemonSwordLock)
                {
                    ui = _DemonSword;
                }
                return ui;
            }
            set
            {
                lock (DemonSwordLock)
                {
                    _DemonSword = value;
                }
            }
        }

        public int Dest_X
        {
            get
            {
                int i;

                lock (DestXLock)
                {
                    i = _Dest_X;
                }
                return i;
            }
            set
            {
                lock (DestXLock)
                {
                    _Dest_X = value;
                }
            }
        }

        public int Dest_Y
        {
            get
            {
                int i;

                lock (DestYLock)
                {
                    i = _Dest_Y;
                }
                return i;
            }
            set
            {
                lock (DestYLock)
                {
                    _Dest_Y = value;
                }
            }
        }

        public int Dest_Z
        {
            get
            {
                int i;

                lock (DestZLock)
                {
                    i = _Dest_Z;
                }
                return i;
            }
            set
            {
                lock (DestZLock)
                {
                    _Dest_Z = value;
                }
            }
        }

        public uint DEX
        {
            get
            {
                uint ui;

                lock (DEXLock)
                {
                    ui = _DEX;
                }
                return ui;
            }
            set
            {
                lock (DEXLock)
                {
                    _DEX = value;
                }
            }
        }

        public byte EnchantAmount
        {
            get
            {
                byte b;

                lock (EnchantAmountLock)
                {
                    b = _EnchantAmount;
                }
                return b;
            }
            set
            {
                lock (EnchantAmountLock)
                {
                    _EnchantAmount = value;
                }
            }
        }

        public uint Evasion
        {
            get
            {
                uint ui;

                lock (EvasionLock)
                {
                    ui = _Evasion;
                }
                return ui;
            }
            set
            {
                lock (EvasionLock)
                {
                    _Evasion = value;
                }
            }
        }

        public uint Face
        {
            get
            {
                uint ui;

                lock (FaceLock)
                {
                    ui = _Face;
                }
                return ui;
            }
            set
            {
                lock (FaceLock)
                {
                    _Face = value;
                }
            }
        }

        public byte FindParty
        {
            get
            {
                byte b;

                lock (FindPartyLock)
                {
                    b = _FindParty;
                }
                return b;
            }
            set
            {
                lock (FindPartyLock)
                {
                    _FindParty = value;
                }
            }
        }

        public int FishX
        {
            get
            {
                int i;

                lock (FishXLock)
                {
                    i = _FishX;
                }
                return i;
            }
            set
            {
                lock (FishXLock)
                {
                    _FishX = value;
                }
            }
        }

        public int FishY
        {
            get
            {
                int i;

                lock (FishYLock)
                {
                    i = _FishY;
                }
                return i;
            }
            set
            {
                lock (FishYLock)
                {
                    _FishY = value;
                }
            }
        }

        public int FishZ
        {
            get
            {
                int i;

                lock (FishZLock)
                {
                    i = _FishZ;
                }
                return i;
            }
            set
            {
                lock (FishZLock)
                {
                    _FishZ = value;
                }
            }
        }

        public uint flRunSpeed
        {
            get
            {
                uint ui;

                lock (flRunSpeedLock)
                {
                    ui = _flRunSpeed;
                }
                return ui;
            }
            set
            {
                lock (flRunSpeedLock)
                {
                    _flRunSpeed = value;
                }
            }
        }

        public uint flWalkSpeed
        {
            get
            {
                uint ui;

                lock (flWalkSpeedLock)
                {
                    ui = _flWalkSpeed;
                }
                return ui;
            }
            set
            {
                lock (flWalkSpeedLock)
                {
                    _flWalkSpeed = value;
                }
            }
        }

        public uint FlyRunSpeed
        {
            get
            {
                uint ui;

                lock (FlyRunSpeedLock)
                {
                    ui = _FlyRunSpeed;
                }
                return ui;
            }
            set
            {
                lock (FlyRunSpeedLock)
                {
                    _FlyRunSpeed = value;
                }
            }
        }

        public uint FlyWalkSpeed
        {
            get
            {
                uint ui;

                lock (FlyWalkSpeedLock)
                {
                    ui = _FlyWalkSpeed;
                }
                return ui;
            }
            set
            {
                lock (FlyWalkSpeedLock)
                {
                    _FlyWalkSpeed = value;
                }
            }
        }

        public uint Focus
        {
            get
            {
                uint ui;

                lock (FocusLock)
                {
                    ui = _Focus;
                }
                return ui;
            }
            set
            {
                lock (FocusLock)
                {
                    _Focus = value;
                }
            }
        }

        public bool Got_Skills
        {
            get
            {
                bool flag;

                lock (Got_SkillsLock)
                {
                    flag = _Got_Skills;
                }
                return flag;
            }
            set
            {
                lock (Got_SkillsLock)
                {
                    _Got_Skills = value;
                }
            }
        }

        public uint HairColor
        {
            get
            {
                uint ui;

                lock (HairColorLock)
                {
                    ui = _HairColor;
                }
                return ui;
            }
            set
            {
                lock (HairColorLock)
                {
                    _HairColor = value;
                }
            }
        }

        public uint HairSytle
        {
            get
            {
                uint ui;

                lock (HairSytleLock)
                {
                    ui = _HairSytle;
                }
                return ui;
            }
            set
            {
                lock (HairSytleLock)
                {
                    _HairSytle = value;
                }
            }
        }

        public byte hasDwarfCraft
        {
            get
            {
                byte b;

                lock (hasDwarfCraftLock)
                {
                    b = _hasDwarfCraft;
                }
                return b;
            }
            set
            {
                lock (hasDwarfCraftLock)
                {
                    _hasDwarfCraft = value;
                }
            }
        }

        public int Heading
        {
            get
            {
                int i;

                lock (HeadingLock)
                {
                    i = _Heading;
                }
                return i;
            }
            set
            {
                lock (HeadingLock)
                {
                    _Heading = value;
                }
            }
        }

        public byte HeroGlow
        {
            get
            {
                byte b;

                lock (HeroGlowLock)
                {
                    b = _HeroGlow;
                }
                return b;
            }
            set
            {
                lock (HeroGlowLock)
                {
                    _HeroGlow = value;
                }
            }
        }

        public byte HeroIcon
        {
            get
            {
                byte b;

                lock (HeroIconLock)
                {
                    b = _HeroIcon;
                }
                return b;
            }
            set
            {
                lock (HeroIconLock)
                {
                    _HeroIcon = value;
                }
            }
        }

        public uint INT
        {
            get
            {
                uint ui;

                lock (INTLock)
                {
                    ui = _INT;
                }
                return ui;
            }
            set
            {
                lock (INTLock)
                {
                    _INT = value;
                }
            }
        }

        public ushort InventoryLimit
        {
            get
            {
                ushort ush;

                lock (InventoryLimitLock)
                {
                    ush = _InventoryLimit;
                }
                return ush;
            }
            set
            {
                lock (InventoryLimitLock)
                {
                    _InventoryLimit = value;
                }
            }
        }

        public uint isClanLeader
        {
            get
            {
                uint ui;

                lock (isClanLeaderLock)
                {
                    ui = _isClanLeader;
                }
                return ui;
            }
            set
            {
                lock (isClanLeaderLock)
                {
                    _isClanLeader = value;
                }
            }
        }

        public byte isFishing
        {
            get
            {
                byte b;

                lock (isFishingLock)
                {
                    b = _isFishing;
                }
                return b;
            }
            set
            {
                lock (isFishingLock)
                {
                    _isFishing = value;
                }
            }
        }

        public uint isRunning
        {
            get
            {
                uint ui;

                lock (isRunningLock)
                {
                    ui = _isRunning;
                }
                return ui;
            }
            set
            {
                lock (isRunningLock)
                {
                    _isRunning = value;
                }
            }
        }

        public uint itm_Back
        {
            get
            {
                uint ui;

                lock (itm_BackLock)
                {
                    ui = _itm_Back;
                }
                return ui;
            }
            set
            {
                lock (itm_BackLock)
                {
                    _itm_Back = value;
                }
            }
        }

        public uint itm_Chest
        {
            get
            {
                uint ui;

                lock (itm_ChestLock)
                {
                    ui = _itm_Chest;
                }
                return ui;
            }
            set
            {
                lock (itm_ChestLock)
                {
                    _itm_Chest = value;
                }
            }
        }

        public uint itm_Face
        {
            get
            {
                uint ui;

                lock (itm_FaceLock)
                {
                    ui = _itm_Face;
                }
                return ui;
            }
            set
            {
                lock (itm_FaceLock)
                {
                    _itm_Face = value;
                }
            }
        }

        public uint itm_Feet
        {
            get
            {
                uint ui;

                lock (itm_FeetLock)
                {
                    ui = _itm_Feet;
                }
                return ui;
            }
            set
            {
                lock (itm_FeetLock)
                {
                    _itm_Feet = value;
                }
            }
        }

        public uint itm_Gloves
        {
            get
            {
                uint ui;

                lock (itm_GlovesLock)
                {
                    ui = _itm_Gloves;
                }
                return ui;
            }
            set
            {
                lock (itm_GlovesLock)
                {
                    _itm_Gloves = value;
                }
            }
        }

        public uint itm_Hair
        {
            get
            {
                uint ui;

                lock (itm_HairLock)
                {
                    ui = _itm_Hair;
                }
                return ui;
            }
            set
            {
                lock (itm_HairLock)
                {
                    _itm_Hair = value;
                }
            }
        }

        public uint itm_Head
        {
            get
            {
                uint ui;

                lock (itm_HeadLock)
                {
                    ui = _itm_Head;
                }
                return ui;
            }
            set
            {
                lock (itm_HeadLock)
                {
                    _itm_Head = value;
                }
            }
        }

        public uint itm_LEar
        {
            get
            {
                uint ui;

                lock (itm_LEarLock)
                {
                    ui = _itm_LEar;
                }
                return ui;
            }
            set
            {
                lock (itm_LEarLock)
                {
                    _itm_LEar = value;
                }
            }
        }

        public uint itm_Legs
        {
            get
            {
                uint ui;

                lock (itm_LegsLock)
                {
                    ui = _itm_Legs;
                }
                return ui;
            }
            set
            {
                lock (itm_LegsLock)
                {
                    _itm_Legs = value;
                }
            }
        }

        public uint itm_LFinger
        {
            get
            {
                uint ui;

                lock (itm_LFingerLock)
                {
                    ui = _itm_LFinger;
                }
                return ui;
            }
            set
            {
                lock (itm_LFingerLock)
                {
                    _itm_LFinger = value;
                }
            }
        }

        public uint itm_LHand
        {
            get
            {
                uint ui;

                lock (itm_LHandLock)
                {
                    ui = _itm_LHand;
                }
                return ui;
            }
            set
            {
                lock (itm_LHandLock)
                {
                    _itm_LHand = value;
                }
            }
        }

        public uint itm_LRHand
        {
            get
            {
                uint ui;

                lock (itm_LRHandLock)
                {
                    ui = _itm_LRHand;
                }
                return ui;
            }
            set
            {
                lock (itm_LRHandLock)
                {
                    _itm_LRHand = value;
                }
            }
        }

        public uint itm_Neck
        {
            get
            {
                uint ui;

                lock (itm_NeckLock)
                {
                    ui = _itm_Neck;
                }
                return ui;
            }
            set
            {
                lock (itm_NeckLock)
                {
                    _itm_Neck = value;
                }
            }
        }

        public uint itm_REar
        {
            get
            {
                uint ui;

                lock (itm_REarLock)
                {
                    ui = _itm_REar;
                }
                return ui;
            }
            set
            {
                lock (itm_REarLock)
                {
                    _itm_REar = value;
                }
            }
        }

        public uint itm_RFinger
        {
            get
            {
                uint ui;

                lock (itm_RFingerLock)
                {
                    ui = _itm_RFinger;
                }
                return ui;
            }
            set
            {
                lock (itm_RFingerLock)
                {
                    _itm_RFinger = value;
                }
            }
        }

        public uint itm_RHand
        {
            get
            {
                uint ui;

                lock (itm_RHandLock)
                {
                    ui = _itm_RHand;
                }
                return ui;
            }
            set
            {
                lock (itm_RHandLock)
                {
                    _itm_RHand = value;
                }
            }
        }

        public uint itm_Under
        {
            get
            {
                uint ui;

                lock (itm_UnderLock)
                {
                    ui = _itm_Under;
                }
                return ui;
            }
            set
            {
                lock (itm_UnderLock)
                {
                    _itm_Under = value;
                }
            }
        }

        public uint Karma
        {
            get
            {
                uint ui;

                lock (KarmaLock)
                {
                    ui = _Karma;
                }
                return ui;
            }
            set
            {
                lock (KarmaLock)
                {
                    _Karma = value;
                }
            }
        }

        public int last_MAPX
        {
            get
            {
                int i;

                lock (last_MAPXLock)
                {
                    i = _last_MAPX;
                }
                return i;
            }
            set
            {
                lock (last_MAPXLock)
                {
                    _last_MAPX = value;
                }
            }
        }

        public int last_MAPY
        {
            get
            {
                int i;

                lock (last_MAPYLock)
                {
                    i = _last_MAPY;
                }
                return i;
            }
            set
            {
                lock (last_MAPYLock)
                {
                    _last_MAPY = value;
                }
            }
        }

        public DateTime LastBuffTime
        {
            get
            {
                DateTime dateTime;

                lock (lastbufftimeLock)
                {
                    dateTime = _lastbufftime;
                }
                return dateTime;
            }
            set
            {
                lock (lastbufftimeLock)
                {
                    _lastbufftime = value;
                }
            }
        }

        public DateTime lastMoveTime
        {
            get
            {
                DateTime dateTime;

                lock (lastMoveTimeLock)
                {
                    dateTime = _lastMoveTime;
                }
                return dateTime;
            }
            set
            {
                lock (lastMoveTimeLock)
                {
                    _lastMoveTime = value;
                }
            }
        }

        public DateTime lastVerifyTime
        {
            get
            {
                DateTime dateTime;

                lock (lastVerifyTimeLock)
                {
                    dateTime = _lastVerifyTime;
                }
                return dateTime;
            }
            set
            {
                lock (lastVerifyTimeLock)
                {
                    _lastVerifyTime = value;
                }
            }
        }

        public uint Level
        {
            get
            {
                uint ui;

                lock (LevelLock)
                {
                    ui = _Level;
                }
                return ui;
            }
            set
            {
                lock (LevelLock)
                {
                    _Level = value;
                }
            }
        }

        public uint Matk
        {
            get
            {
                uint ui;

                lock (MatkLock)
                {
                    ui = _Matk;
                }
                return ui;
            }
            set
            {
                lock (MatkLock)
                {
                    _Matk = value;
                }
            }
        }

        public uint MatkSpeed
        {
            get
            {
                uint ui;

                lock (MatkSpeedLock)
                {
                    ui = _MatkSpeed;
                }
                return ui;
            }
            set
            {
                lock (MatkSpeedLock)
                {
                    _MatkSpeed = value;
                }
            }
        }

        public double Max_CP
        {
            get
            {
                double d;

                lock (MaxCPLock)
                {
                    d = _Max_CP;
                }
                return d;
            }
            set
            {
                lock (MaxCPLock)
                {
                    _Max_CP = value;
                }
            }
        }

        public double Max_HP
        {
            get
            {
                double d;

                lock (MaxHPLock)
                {
                    d = _Max_HP;
                }
                return d;
            }
            set
            {
                lock (MaxHPLock)
                {
                    _Max_HP = value;
                }
            }
        }

        public uint Max_Load
        {
            get
            {
                uint ui;

                lock (Max_LoadLock)
                {
                    ui = _Max_Load;
                }
                return ui;
            }
            set
            {
                lock (Max_LoadLock)
                {
                    _Max_Load = value;
                }
            }
        }

        public double Max_MP
        {
            get
            {
                double d;

                lock (MaxMPLock)
                {
                    d = _Max_MP;
                }
                return d;
            }
            set
            {
                lock (MaxMPLock)
                {
                    _Max_MP = value;
                }
            }
        }

        public uint MaxTats
        {
            get
            {
                uint ui;

                lock (MaxTatsLock)
                {
                    ui = _MaxTats;
                }
                return ui;
            }
            set
            {
                lock (MaxTatsLock)
                {
                    _MaxTats = value;
                }
            }
        }

        public uint MDef
        {
            get
            {
                uint ui;

                lock (MDefLock)
                {
                    ui = _MDef;
                }
                return ui;
            }
            set
            {
                lock (MDefLock)
                {
                    _MDef = value;
                }
            }
        }

        public uint MEN
        {
            get
            {
                uint ui;

                lock (MENLock)
                {
                    ui = _MEN;
                }
                return ui;
            }
            set
            {
                lock (MENLock)
                {
                    _MEN = value;
                }
            }
        }

        public byte MountType
        {
            get
            {
                byte b;

                lock (MountTypeLock)
                {
                    b = _MountType;
                }
                return b;
            }
            set
            {
                lock (MountTypeLock)
                {
                    _MountType = value;
                }
            }
        }

        public double MoveSpeedMult
        {
            get
            {
                double d;

                lock (MoveSpeedMultLock)
                {
                    d = _MoveSpeedMult;
                }
                return d;
            }
            set
            {
                lock (MoveSpeedMultLock)
                {
                    _MoveSpeedMult = value;
                }
            }
        }

        public uint MoveTarget
        {
            get
            {
                uint ui;

                lock (MoveTargetLock)
                {
                    ui = _MoveTarget;
                }
                return ui;
            }
            set
            {
                lock (MoveTargetLock)
                {
                    _MoveTarget = value;
                }
            }
        }

        public int MoveTargetType
        {
            get
            {
                int i;

                lock (MoveTargetTypeLock)
                {
                    i = _MoveTargetType;
                }
                return i;
            }
            set
            {
                lock (MoveTargetTypeLock)
                {
                    _MoveTargetType = value;
                }
            }
        }

        public bool Moving
        {
            get
            {
                bool flag;

                lock (moveLock)
                {
                    flag = _Moving;
                }
                return flag;
            }
            set
            {
                lock (moveLock)
                {
                    _Moving = value;
                }
            }
        }


        public ArrayList my_skills
        {
            get
            {
                ArrayList arrayList;

                lock (myskillsLock)
                {
                    arrayList = _my_skills;
                }
                return arrayList;
            }
            set
            {
                lock (myskillsLock)
                {
                    _my_skills = value;
                }
            }
        }

        public string Name
        {
            get
            {
                string s;

                lock (NameLock)
                {
                    s = _Name;
                }
                return s;
            }
            set
            {
                lock (NameLock)
                {
                    _Name = value;
                }
            }
        }

        public uint NameColor
        {
            get
            {
                uint ui;

                lock (NameColorLock)
                {
                    ui = _NameColor;
                }
                return ui;
            }
            set
            {
                lock (NameColorLock)
                {
                    _NameColor = value;
                }
            }
        }

        public uint obj_Back
        {
            get
            {
                uint ui;

                lock (obj_BackLock)
                {
                    ui = _obj_Back;
                }
                return ui;
            }
            set
            {
                lock (obj_BackLock)
                {
                    _obj_Back = value;
                }
            }
        }

        public uint obj_Chest
        {
            get
            {
                uint ui;

                lock (obj_ChestLock)
                {
                    ui = _obj_Chest;
                }
                return ui;
            }
            set
            {
                lock (obj_ChestLock)
                {
                    _obj_Chest = value;
                }
            }
        }

        public uint obj_Face
        {
            get
            {
                uint ui;

                lock (obj_FaceLock)
                {
                    ui = _obj_Face;
                }
                return ui;
            }
            set
            {
                lock (obj_FaceLock)
                {
                    _obj_Face = value;
                }
            }
        }

        public uint obj_Feet
        {
            get
            {
                uint ui;

                lock (obj_FeetLock)
                {
                    ui = _obj_Feet;
                }
                return ui;
            }
            set
            {
                lock (obj_FeetLock)
                {
                    _obj_Feet = value;
                }
            }
        }

        public uint obj_Gloves
        {
            get
            {
                uint ui;

                lock (obj_GlovesLock)
                {
                    ui = _obj_Gloves;
                }
                return ui;
            }
            set
            {
                lock (obj_GlovesLock)
                {
                    _obj_Gloves = value;
                }
            }
        }

        public uint obj_Hair
        {
            get
            {
                uint ui;

                lock (obj_HairLock)
                {
                    ui = _obj_Hair;
                }
                return ui;
            }
            set
            {
                lock (obj_HairLock)
                {
                    _obj_Hair = value;
                }
            }
        }

        public uint obj_Head
        {
            get
            {
                uint ui;

                lock (obj_HeadLock)
                {
                    ui = _obj_Head;
                }
                return ui;
            }
            set
            {
                lock (obj_HeadLock)
                {
                    _obj_Head = value;
                }
            }
        }

        public uint obj_LEar
        {
            get
            {
                uint ui;

                lock (obj_LEarLock)
                {
                    ui = _obj_LEar;
                }
                return ui;
            }
            set
            {
                lock (obj_LEarLock)
                {
                    _obj_LEar = value;
                }
            }
        }

        public uint obj_Legs
        {
            get
            {
                uint ui;

                lock (obj_LegsLock)
                {
                    ui = _obj_Legs;
                }
                return ui;
            }
            set
            {
                lock (obj_LegsLock)
                {
                    _obj_Legs = value;
                }
            }
        }

        public uint obj_LFinger
        {
            get
            {
                uint ui;

                lock (obj_LFingerLock)
                {
                    ui = _obj_LFinger;
                }
                return ui;
            }
            set
            {
                lock (obj_LFingerLock)
                {
                    _obj_LFinger = value;
                }
            }
        }

        public uint obj_LHand
        {
            get
            {
                uint ui;

                lock (obj_LHandLock)
                {
                    ui = _obj_LHand;
                }
                return ui;
            }
            set
            {
                lock (obj_LHandLock)
                {
                    _obj_LHand = value;
                }
            }
        }

        public uint obj_LRHand
        {
            get
            {
                uint ui;

                lock (obj_LRHandLock)
                {
                    ui = _obj_LRHand;
                }
                return ui;
            }
            set
            {
                lock (obj_LRHandLock)
                {
                    _obj_LRHand = value;
                }
            }
        }

        public uint obj_Neck
        {
            get
            {
                uint ui;

                lock (obj_NeckLock)
                {
                    ui = _obj_Neck;
                }
                return ui;
            }
            set
            {
                lock (obj_NeckLock)
                {
                    _obj_Neck = value;
                }
            }
        }

        public uint obj_REar
        {
            get
            {
                uint ui;

                lock (obj_REarLock)
                {
                    ui = _obj_REar;
                }
                return ui;
            }
            set
            {
                lock (obj_REarLock)
                {
                    _obj_REar = value;
                }
            }
        }

        public uint obj_RFinger
        {
            get
            {
                uint ui;

                lock (obj_RFingerLock)
                {
                    ui = _obj_RFinger;
                }
                return ui;
            }
            set
            {
                lock (obj_RFingerLock)
                {
                    _obj_RFinger = value;
                }
            }
        }

        public uint obj_RHand
        {
            get
            {
                uint ui;

                lock (obj_RHandLock)
                {
                    ui = _obj_RHand;
                }
                return ui;
            }
            set
            {
                lock (obj_RHandLock)
                {
                    _obj_RHand = value;
                }
            }
        }

        public uint obj_Under
        {
            get
            {
                uint ui;

                lock (obj_UnderLock)
                {
                    ui = _obj_Under;
                }
                return ui;
            }
            set
            {
                lock (obj_UnderLock)
                {
                    _obj_Under = value;
                }
            }
        }

        public uint ObjID
        {
            get
            {
                uint ui;

                lock (ObjIDLock)
                {
                    ui = _ObjID;
                }
                return ui;
            }
            set
            {
                lock (ObjIDLock)
                {
                    _ObjID = value;
                }
            }
        }

        public uint PartyCount
        {
            get
            {
                uint ui;

                lock (PartyCountLock)
                {
                    ui = _PartyCount;
                }
                return ui;
            }
            set
            {
                lock (PartyCountLock)
                {
                    _PartyCount = value;
                }
            }
        }

        public uint PartyLeader
        {
            get
            {
                uint ui;

                lock (PartyLeaderLock)
                {
                    ui = _PartyLeader;
                }
                return ui;
            }
            set
            {
                lock (PartyLeaderLock)
                {
                    _PartyLeader = value;
                }
            }
        }

        public uint PartyLoot
        {
            get
            {
                uint ui;

                lock (PartyLootLock)
                {
                    ui = _PartyLoot;
                }
                return ui;
            }
            set
            {
                lock (PartyLootLock)
                {
                    _PartyLoot = value;
                }
            }
        }

        public ArrayList PartyMembers
        {
            get
            {
                ArrayList arrayList;

                lock (PartyMembersLock)
                {
                    arrayList = _PartyMembers;
                }
                return arrayList;
            }
            set
            {
                lock (PartyMembersLock)
                {
                    _PartyMembers = value;
                }
            }
        }

        public uint Patk
        {
            get
            {
                uint ui;

                lock (PatkLock)
                {
                    ui = _Patk;
                }
                return ui;
            }
            set
            {
                lock (PatkLock)
                {
                    _Patk = value;
                }
            }
        }

        public uint PatkSpeed
        {
            get
            {
                uint ui;

                lock (PatkSpeedLock)
                {
                    ui = _PatkSpeed;
                }
                return ui;
            }
            set
            {
                lock (PatkSpeedLock)
                {
                    _PatkSpeed = value;
                }
            }
        }

        public uint PDef
        {
            get
            {
                uint ui;

                lock (PDefLock)
                {
                    ui = _PDef;
                }
                return ui;
            }
            set
            {
                lock (PDefLock)
                {
                    _PDef = value;
                }
            }
        }

        public uint PKCount
        {
            get
            {
                uint ui;

                lock (PKCountLock)
                {
                    ui = _PKCount;
                }
                return ui;
            }
            set
            {
                lock (PKCountLock)
                {
                    _PKCount = value;
                }
            }
        }

        public uint PledgeClass
        {
            get
            {
                uint ui;

                lock (PledgeClassLock)
                {
                    ui = _PledgeClass;
                }
                return ui;
            }
            set
            {
                lock (PledgeClassLock)
                {
                    _PledgeClass = value;
                }
            }
        }

        public byte PrivateStoreType
        {
            get
            {
                byte b;

                lock (PrivateStoreTypeLock)
                {
                    b = _PrivateStoreType;
                }
                return b;
            }
            set
            {
                lock (PrivateStoreTypeLock)
                {
                    _PrivateStoreType = value;
                }
            }
        }

        public uint PvPCount
        {
            get
            {
                uint ui;

                lock (PvPCountLock)
                {
                    ui = _PvPCount;
                }
                return ui;
            }
            set
            {
                lock (PvPCountLock)
                {
                    _PvPCount = value;
                }
            }
        }

        public uint PvPFlag
        {
            get
            {
                uint ui;

                lock (PvPFlagLock)
                {
                    ui = _PvPFlag;
                }
                return ui;
            }
            set
            {
                lock (PvPFlagLock)
                {
                    _PvPFlag = value;
                }
            }
        }

        public uint Race
        {
            get
            {
                uint ui;

                lock (RaceLock)
                {
                    ui = _Race;
                }
                return ui;
            }
            set
            {
                lock (RaceLock)
                {
                    _Race = value;
                }
            }
        }

        public ushort RecAmount
        {
            get
            {
                ushort ush;

                lock (RecAmountLock)
                {
                    ush = _RecAmount;
                }
                return ush;
            }
            set
            {
                lock (RecAmountLock)
                {
                    _RecAmount = value;
                }
            }
        }

        public ushort RecLeft
        {
            get
            {
                ushort ush;

                lock (RecLeftLock)
                {
                    ush = _RecLeft;
                }
                return ush;
            }
            set
            {
                lock (RecLeftLock)
                {
                    _RecLeft = value;
                }
            }
        }

        public uint RunSpeed
        {
            get
            {
                uint ui;

                lock (RunSpeedLock)
                {
                    ui = _RunSpeed;
                }
                return ui;
            }
            set
            {
                lock (RunSpeedLock)
                {
                    _RunSpeed = value;
                }
            }
        }

        public byte[] sessionID
        {
            get
            {
                byte[] bArr;

                lock (sessionIDLock)
                {
                    bArr = _sessionID;
                }
                return bArr;
            }
            set
            {
                lock (sessionIDLock)
                {
                    _sessionID = value;
                }
            }
        }

        public uint Sex
        {
            get
            {
                uint ui;

                lock (SexLock)
                {
                    ui = _Sex;
                }
                return ui;
            }
            set
            {
                lock (SexLock)
                {
                    _Sex = value;
                }
            }
        }

        public uint SP
        {
            get
            {
                uint ui;

                lock (SPLock)
                {
                    ui = _SP;
                }
                return ui;
            }
            set
            {
                lock (SPLock)
                {
                    _SP = value;
                }
            }
        }

        public uint SpecialEffects
        {
            get
            {
                uint ui;

                lock (SpecialEffectsLock)
                {
                    ui = _SpecialEffects;
                }
                return ui;
            }
            set
            {
                lock (SpecialEffectsLock)
                {
                    _SpecialEffects = value;
                }
            }
        }

        public uint STR
        {
            get
            {
                uint ui;

                lock (STRLock)
                {
                    ui = _STR;
                }
                return ui;
            }
            set
            {
                lock (STRLock)
                {
                    _STR = value;
                }
            }
        }

        public uint SwimRunSpeed
        {
            get
            {
                uint ui;

                lock (SwimRunSpeedLock)
                {
                    ui = _SwimRunSpeed;
                }
                return ui;
            }
            set
            {
                lock (SwimRunSpeedLock)
                {
                    _SwimRunSpeed = value;
                }
            }
        }

        public uint SwimWalkSpeed
        {
            get
            {
                uint ui;

                lock (SwimWalkSpeedLock)
                {
                    ui = _SwimWalkSpeed;
                }
                return ui;
            }
            set
            {
                lock (SwimWalkSpeedLock)
                {
                    _SwimWalkSpeed = value;
                }
            }
        }

        public uint Symbol1
        {
            get
            {
                uint ui;

                lock (Symbol1Lock)
                {
                    ui = _Symbol1;
                }
                return ui;
            }
            set
            {
                lock (Symbol1Lock)
                {
                    _Symbol1 = value;
                }
            }
        }

        public uint Symbol2
        {
            get
            {
                uint ui;

                lock (Symbol2Lock)
                {
                    ui = _Symbol2;
                }
                return ui;
            }
            set
            {
                lock (Symbol2Lock)
                {
                    _Symbol2 = value;
                }
            }
        }

        public uint Symbol3
        {
            get
            {
                uint ui;

                lock (Symbol3Lock)
                {
                    ui = _Symbol3;
                }
                return ui;
            }
            set
            {
                lock (Symbol3Lock)
                {
                    _Symbol3 = value;
                }
            }
        }

        public ushort TargetColor
        {
            get
            {
                ushort ush;

                lock (TargetColorLock)
                {
                    ush = _TargetColor;
                }
                return ush;
            }
            set
            {
                lock (TargetColorLock)
                {
                    _TargetColor = value;
                }
            }
        }

        public uint TargetID
        {
            get
            {
                uint ui;

                lock (targetidLock)
                {
                    ui = _TargetID;
                }
                return ui;
            }
            set
            {
                lock (targetidLock)
                {
                    _TargetID = value;
                }
            }
        }

        public bool TargetSpoiled
        {
            get
            {
                bool flag;

                lock (targetspoiledLock)
                {
                    flag = _TargetSpoiled;
                }
                return flag;
            }
            set
            {
                lock (targetspoiledLock)
                {
                    _TargetSpoiled = value;
                }
            }
        }

        public int TargetType
        {
            get
            {
                int i;

                lock (targettypeLock)
                {
                    i = _TargetType;
                }
                return i;
            }
            set
            {
                lock (targettypeLock)
                {
                    _TargetType = value;
                }
            }
        }

        public byte TeamCircle
        {
            get
            {
                byte b;

                lock (TeamCircleLock)
                {
                    b = _TeamCircle;
                }
                return b;
            }
            set
            {
                lock (TeamCircleLock)
                {
                    _TeamCircle = value;
                }
            }
        }

        public string Title
        {
            get
            {
                string s;

                lock (TitleLock)
                {
                    s = _Title;
                }
                return s;
            }
            set
            {
                lock (TitleLock)
                {
                    _Title = value;
                }
            }
        }

        public uint TitleColor
        {
            get
            {
                uint ui;

                lock (TitleColorLock)
                {
                    ui = _TitleColor;
                }
                return ui;
            }
            set
            {
                lock (TitleColorLock)
                {
                    _TitleColor = value;
                }
            }
        }

        public uint WalkSpeed
        {
            get
            {
                uint ui;

                lock (WalkSpeedLock)
                {
                    ui = _WalkSpeed;
                }
                return ui;
            }
            set
            {
                lock (WalkSpeedLock)
                {
                    _WalkSpeed = value;
                }
            }
        }

        public uint WIT
        {
            get
            {
                uint ui;

                lock (WITLock)
                {
                    ui = _WIT;
                }
                return ui;
            }
            set
            {
                lock (WITLock)
                {
                    _WIT = value;
                }
            }
        }

        public int X
        {
            get
            {
                int i;

                lock (XLock)
                {
                    i = _X;
                }
                return i;
            }
            set
            {
                lock (XLock)
                {
                    _X = value;
                }
            }
        }

        public ulong XP
        {
            get
            {
                ulong ul;

                lock (XPLock)
                {
                    ul = _XP;
                }
                return ul;
            }
            set
            {
                lock (XPLock)
                {
                    _XP = value;
                }
            }
        }

        public uint xxx
        {
            get
            {
                uint ui;

                lock (xxxLock)
                {
                    ui = _xxx;
                }
                return ui;
            }
            set
            {
                lock (xxxLock)
                {
                    _xxx = value;
                }
            }
        }

        public uint xxx2
        {
            get
            {
                uint ui;

                lock (xxx2Lock)
                {
                    ui = _xxx2;
                }
                return ui;
            }
            set
            {
                lock (xxx2Lock)
                {
                    _xxx2 = value;
                }
            }
        }

        public uint xxx3
        {
            get
            {
                uint ui;

                lock (xxx3Lock)
                {
                    ui = _xxx3;
                }
                return ui;
            }
            set
            {
                lock (xxx3Lock)
                {
                    _xxx3 = value;
                }
            }
        }

        public int Y
        {
            get
            {
                int i;

                lock (YLock)
                {
                    i = _Y;
                }
                return i;
            }
            set
            {
                lock (YLock)
                {
                    _Y = value;
                }
            }
        }

        public int Z
        {
            get
            {
                int i;

                lock (ZLock)
                {
                    i = _Z;
                }
                return i;
            }
            set
            {
                lock (ZLock)
                {
                    _Z = value;
                }
            }
        }

        public Player_Info()
        {
            _sessionID = new byte[4];
            _Got_Skills = false;
            myskillsLock = new Object();
            lastbufftimeLock = new Object();
            mybuffsLock = new Object();
            botstateLock = new Object();
            bufftargetLock = new Object();
            buffskillLock = new Object();
            targetidLock = new Object();
            targettypeLock = new Object();
            targetspoiledLock = new Object();
            moveLock = new Object();
            PartyLeaderLock = new Object();
            PartyMembersLock = new Object();
            PartyLootLock = new Object();
            PartyCountLock = new Object();
            lastVerifyTimeLock = new Object();
            lastMoveTimeLock = new Object();
            MoveTargetTypeLock = new Object();
            MoveTargetLock = new Object();
            DestZLock = new Object();
            DestYLock = new Object();
            DestXLock = new Object();
            MaxHPLock = new Object();
            CurHPLock = new Object();
            MaxMPLock = new Object();
            CurMPLock = new Object();
            MaxCPLock = new Object();
            CurCPLock = new Object();
            XLock = new Object();
            YLock = new Object();
            ZLock = new Object();
            TargetColorLock = new Object();
            Got_SkillsLock = new Object();
            last_MAPYLock = new Object();
            last_MAPXLock = new Object();
            MaxTatsLock = new Object();
            Symbol3Lock = new Object();
            Symbol2Lock = new Object();
            Symbol1Lock = new Object();
            NameColorLock = new Object();
            TitleColorLock = new Object();
            PledgeClassLock = new Object();
            DemonSwordLock = new Object();
            FishZLock = new Object();
            FishYLock = new Object();
            FishXLock = new Object();
            isFishingLock = new Object();
            HeroGlowLock = new Object();
            HeroIconLock = new Object();
            XPLock = new Object();
            SPLock = new Object();
            ClanCrestIDLargeLock = new Object();
            TeamCircleLock = new Object();
            EnchantAmountLock = new Object();
            SpecialEffectsLock = new Object();
            InventoryLimitLock = new Object();
            RecAmountLock = new Object();
            RecLeftLock = new Object();
            CollisionHeightLock = new Object();
            CollisionRadiusLock = new Object();
            AttackSpeedMultLock = new Object();
            MoveSpeedMultLock = new Object();
            FlyWalkSpeedLock = new Object();
            FlyRunSpeedLock = new Object();
            flWalkSpeedLock = new Object();
            flRunSpeedLock = new Object();
            SwimWalkSpeedLock = new Object();
            SwimRunSpeedLock = new Object();
            WalkSpeedLock = new Object();
            RunSpeedLock = new Object();
            isRunningLock = new Object();
            ClanPrivilegesLock = new Object();
            AbnormalEffectsLock = new Object();
            FindPartyLock = new Object();
            CubicsLock = new Object();
            CubicCountLock = new Object();
            PvPCountLock = new Object();
            PKCountLock = new Object();
            hasDwarfCraftLock = new Object();
            PrivateStoreTypeLock = new Object();
            MountTypeLock = new Object();
            isClanLeaderLock = new Object();
            AllyCrestIDLock = new Object();
            AllyIDLock = new Object();
            ClanCrestIDLock = new Object();
            ClanIDLock = new Object();
            AccessLevelLock = new Object();
            FaceLock = new Object();
            HairColorLock = new Object();
            HairSytleLock = new Object();
            KarmaLock = new Object();
            PvPFlagLock = new Object();
            MDefLock = new Object();
            MatkSpeedLock = new Object();
            MatkLock = new Object();
            FocusLock = new Object();
            AccuracyLock = new Object();
            EvasionLock = new Object();
            PDefLock = new Object();
            PatkSpeedLock = new Object();
            PatkLock = new Object();
            itm_HairLock = new Object();
            itm_FaceLock = new Object();
            itm_LRHandLock = new Object();
            itm_BackLock = new Object();
            itm_FeetLock = new Object();
            itm_LegsLock = new Object();
            itm_ChestLock = new Object();
            itm_GlovesLock = new Object();
            itm_LHandLock = new Object();
            itm_RHandLock = new Object();
            itm_HeadLock = new Object();
            itm_LFingerLock = new Object();
            itm_RFingerLock = new Object();
            itm_NeckLock = new Object();
            itm_LEarLock = new Object();
            itm_REarLock = new Object();
            itm_UnderLock = new Object();
            obj_HairLock = new Object();
            obj_FaceLock = new Object();
            obj_LRHandLock = new Object();
            obj_BackLock = new Object();
            obj_FeetLock = new Object();
            obj_LegsLock = new Object();
            obj_ChestLock = new Object();
            obj_GlovesLock = new Object();
            obj_LHandLock = new Object();
            obj_RHandLock = new Object();
            obj_HeadLock = new Object();
            obj_LFingerLock = new Object();
            obj_RFingerLock = new Object();
            obj_NeckLock = new Object();
            obj_LEarLock = new Object();
            obj_REarLock = new Object();
            obj_UnderLock = new Object();
            Max_LoadLock = new Object();
            Cur_LoadLock = new Object();
            ObjIDLock = new Object();
            HeadingLock = new Object();
            WITLock = new Object();
            DEXLock = new Object();
            MENLock = new Object();
            CONLock = new Object();
            STRLock = new Object();
            INTLock = new Object();
            xxx3Lock = new Object();
            xxx2Lock = new Object();
            LevelLock = new Object();
            ActiveLock = new Object();
            ClassLock = new Object();
            RaceLock = new Object();
            SexLock = new Object();
            xxxLock = new Object();
            sessionIDLock = new Object();
            TitleLock = new Object();
            NameLock = new Object();
            charIDLock = new Object();
            Moving = false;
            TargetSpoiled = false;
            lastVerifyTime = DateTime.Now;
            BOT_STATE = 0;
            BuffTarget = 0;
            my_skills = new ArrayList();
            PartyMembers = new ArrayList();
            cppots = 0;
            ghppots = 0;
            lesscppots = 0;
            elixirCP_A = 0;
            elixirCP_S = 0;
            elixirHP_A = 0;
            elixirHP_S = 0;
            cppottime = new DateTime();
            ghppottime = new DateTime();
            elixirCPtime = new DateTime();
            elixirHPtime = new DateTime();

            cppottime = DateTime.Now;
            ghppottime = DateTime.Now;
            elixirCPtime = DateTime.Now;
            elixirHPtime = DateTime.Now;
            smallcppottime = DateTime.Now;
        }

        public uint elixirCP_S;
        public uint elixirCP_A;
        public uint elixirHP_S;
        public uint elixirHP_A;

        //public void Load(ByteBuffer buff)
        //{
        //    Name = buff.ReadString();
        //    charID = buff.ReadUInt32();
        //    Title = buff.ReadString();
        //    sessionID[0] = buff.ReadByte();
        //    sessionID[1] = buff.ReadByte();
        //    sessionID[2] = buff.ReadByte();
        //    sessionID[3] = buff.ReadByte();
        //    ClanID = buff.ReadUInt32();
        //    buff.ReadUInt32();
        //    Sex = buff.ReadUInt32();
        //    Race = buff.ReadUInt32();
        //    Class = buff.ReadUInt32();
        //    Active = buff.ReadUInt32();
        //    X = buff.ReadInt32();
        //    Y = buff.ReadInt32();
        //    Z = buff.ReadInt32();
        //    Cur_HP = buff.ReadDouble();
        //    Cur_MP = buff.ReadDouble();
        //    SP = buff.ReadUInt32();
        //    XP = buff.ReadUInt64();
        //    Level = buff.ReadUInt32();
        //    Karma = buff.ReadUInt32();
        //    buff.ReadUInt32();
        //    INT = buff.ReadUInt32();
        //    STR = buff.ReadUInt32();
        //    CON = buff.ReadUInt32();
        //    MEN = buff.ReadUInt32();
        //    DEX = buff.ReadUInt32();
        //    WIT = buff.ReadUInt32();
        //}


        public void Load(ByteBuffer buff)
        {
            this.Name = buff.ReadString();
            this.charID = buff.ReadUInt32();
            this.Title = buff.ReadString();
            this.sessionID[0] = buff.ReadByte();
            this.sessionID[1] = buff.ReadByte();
            this.sessionID[2] = buff.ReadByte();
            this.sessionID[3] = buff.ReadByte();
            this.ClanID = buff.ReadUInt32();
            buff.ReadUInt32();
            this.Sex = buff.ReadUInt32();
            this.Race = buff.ReadUInt32();
            this.Class = buff.ReadUInt32();
            this.Active = buff.ReadUInt32();
            this.X = buff.ReadInt32();
            this.Y = buff.ReadInt32();
            this.Z = buff.ReadInt32();
            this.Cur_HP = buff.ReadDouble();
            this.Cur_MP = buff.ReadDouble();
            this.SP = buff.ReadUInt32();
            this.XP = buff.ReadUInt64();
            this.Level = buff.ReadUInt32();
            this.Karma = buff.ReadUInt32();
            buff.ReadUInt32();
            this.INT = buff.ReadUInt32();
            this.STR = buff.ReadUInt32();
            this.CON = buff.ReadUInt32();
            this.MEN = buff.ReadUInt32();
            this.DEX = buff.ReadUInt32();
            this.WIT = buff.ReadUInt32();
        }

        public void Load_User(ByteBuffer buff)
        {
            this.X = buff.ReadInt32();
            this.Y = buff.ReadInt32();
            this.Z = buff.ReadInt32();
            this.Heading = buff.ReadInt32();
            this.ObjID = buff.ReadUInt32();
            this.Name = buff.ReadString();
            this.Race = buff.ReadUInt32();
            this.Sex = buff.ReadUInt32();
            this.Class = buff.ReadUInt32();
            this.Level = buff.ReadUInt32();
            this.XP = buff.ReadUInt64();
            this.STR = buff.ReadUInt32();
            this.DEX = buff.ReadUInt32();
            this.CON = buff.ReadUInt32();
            this.INT = buff.ReadUInt32();
            this.WIT = buff.ReadUInt32();
            this.MEN = buff.ReadUInt32();
            this.Max_HP = buff.ReadUInt32();
            this.Cur_HP = buff.ReadUInt32();
            this.Max_MP = buff.ReadUInt32();
            this.Cur_MP = buff.ReadUInt32();
            this.SP = buff.ReadUInt32();
            this.Cur_Load = buff.ReadUInt32();
            this.Max_Load = buff.ReadUInt32();
            buff.ReadUInt32();
            //inventory
            uint x;
            ushort y;
            for (int i = 0; i < 50; i++)
                x = buff.ReadUInt32();

            for (int i = 0; i < 14; i++)
                y = buff.ReadUInt16();

            x = buff.ReadUInt32();

            for (int i = 0; i < 12; i++)
                y = buff.ReadUInt16();
            x = buff.ReadUInt32();

            for (int i = 0; i < 20; i++)
                y = buff.ReadUInt16();

            this.Patk = buff.ReadUInt32();
            this.PatkSpeed = buff.ReadUInt32();
            this.PDef = buff.ReadUInt32();
            this.Evasion = buff.ReadUInt32();
            this.Accuracy = buff.ReadUInt32();
            this.Focus = buff.ReadUInt32();
            this.Matk = buff.ReadUInt32();
            this.MatkSpeed = buff.ReadUInt32();
            this.PatkSpeed = buff.ReadUInt32();
            this.MDef = buff.ReadUInt32();
            this.PvPFlag = buff.ReadUInt32();
            this.Karma = buff.ReadUInt32();
            this.RunSpeed = buff.ReadUInt32();
            this.WalkSpeed = buff.ReadUInt32();
            this.SwimRunSpeed = buff.ReadUInt32();
            this.SwimWalkSpeed = buff.ReadUInt32();
            this.flRunSpeed = buff.ReadUInt32();
            this.flWalkSpeed = buff.ReadUInt32();
            this.FlyRunSpeed = buff.ReadUInt32();
            this.FlyWalkSpeed = buff.ReadUInt32();
            this.MoveSpeedMult = buff.ReadDouble();
            this.AttackSpeedMult = buff.ReadDouble();
            this.CollisionRadius = buff.ReadDouble();
            this.CollisionHeight = buff.ReadDouble();
            this.HairSytle = buff.ReadUInt32();
            this.HairColor = buff.ReadUInt32();
            this.Face = buff.ReadUInt32();
            this.AccessLevel = buff.ReadUInt32();
            this.Title = buff.ReadString();
            this.ClanID = buff.ReadUInt32();
            this.ClanCrestID = buff.ReadUInt32();
            this.AllyID = buff.ReadUInt32();
            this.AllyCrestID = buff.ReadUInt32();
            this.isClanLeader = buff.ReadUInt32();
            this.MountType = buff.ReadByte();
            this.PrivateStoreType = buff.ReadByte();
            this.hasDwarfCraft = buff.ReadByte();
            this.PKCount = buff.ReadUInt32();
            this.PvPCount = buff.ReadUInt32();
            this.CubicCount = buff.ReadUInt16();
            this.Cubics = new ArrayList();
            for (uint num1 = 0; num1 < this.CubicCount; num1 += 1)
            {
                ushort num2 = buff.ReadUInt16();
                this.Cubics.Add(num2);
            }
            this.FindParty = buff.ReadByte();
            this.AbnormalEffects = buff.ReadUInt32();
            buff.ReadByte();
            this.ClanPrivileges = buff.ReadUInt32();
            this.RecLeft = buff.ReadUInt16();
            this.RecAmount = buff.ReadUInt16();
            buff.ReadUInt32();
            this.InventoryLimit = buff.ReadUInt16();
            buff.ReadUInt32();
            this.SpecialEffects = buff.ReadUInt32();
            this.Max_CP = buff.ReadUInt32();
            this.Cur_CP = buff.ReadUInt32();
            this.EnchantAmount = buff.ReadByte();
            this.TeamCircle = buff.ReadByte();
            this.ClanCrestIDLarge = buff.ReadUInt32();
            this.HeroIcon = buff.ReadByte();
            this.HeroGlow = buff.ReadByte();
            this.isFishing = buff.ReadByte();
            this.FishX = buff.ReadInt32();
            this.FishY = buff.ReadInt32();
            this.FishZ = buff.ReadInt32();
            this.NameColor = buff.ReadUInt32();
            this.isRunning = buff.ReadByte();
            this.obj_Face = buff.ReadUInt32();
            this.itm_Face = buff.ReadUInt32();
            this.PledgeClass = buff.ReadUInt32();
            buff.ReadUInt32();
            this.TitleColor = buff.ReadUInt32();
            this.DemonSword = buff.ReadUInt32();
            buff.ReadUInt32();
            buff.ReadUInt32();
            buff.ReadUInt32();
            buff.ReadUInt32();
            buff.ReadUInt32();
            buff.ReadUInt32();
            buff.ReadUInt32();
            buff.ReadUInt32();
            buff.ReadUInt32();
            buff.ReadUInt32();
        }

        public void Update(ByteBuffer buff)
        {
            uint num1 = buff.ReadUInt32();
            uint num2 = buff.ReadUInt32();
            switch (num1)
            {
                case 1:
                    this.Level = num2;
                    return;

                case 2:
                    this.XP = num2;
                    return;

                case 3:
                    this.STR = num2;
                    return;

                case 4:
                    this.DEX = num2;
                    return;

                case 5:
                    this.CON = num2;
                    return;

                case 6:
                    this.INT = num2;
                    return;

                case 7:
                    this.WIT = num2;
                    return;

                case 8:
                    this.MEN = num2;
                    return;

                case 9:
                    this.Cur_HP = num2;
                    return;

                case 10:
                    this.Max_HP = num2;
                    return;

                case 11:
                    this.Cur_MP = num2;
                    return;

                case 12:
                    this.Max_MP = num2;
                    return;

                case 13:
                    this.SP = num2;
                    return;

                case 14:
                    this.Cur_Load = num2;
                    return;

                case 15:
                    this.Max_Load = num2;
                    return;

                case 0x10:
                case 0x1c:
                case 0x1d:
                case 30:
                case 0x1f:
                case 0x20:
                    return;

                case 0x11:
                    this.Patk = num2;
                    return;

                case 0x12:
                    this.PatkSpeed = num2;
                    return;

                case 0x13:
                    this.PDef = num2;
                    return;

                case 20:
                    this.Evasion = num2;
                    return;

                case 0x15:
                    this.Accuracy = num2;
                    return;

                case 0x16:
                    this.Focus = num2;
                    return;

                case 0x17:
                    this.Matk = num2;
                    return;

                case 0x18:
                    this.MatkSpeed = num2;
                    return;

                case 0x19:
                    this.MDef = num2;
                    return;

                case 0x1a:
                    this.PvPFlag = num2;
                    return;

                case 0x1b:
                    this.Karma = num2;
                    return;

                case 0x21:
                    this.Cur_CP = num2;
                    return;

                case 0x22:
                    this.Max_CP = num2;
                    return;
            }
        }

        public uint cppots;
        public uint ghppots;
        public uint qhp;
        public uint lesscppots;

        public System.DateTime cppottime;
        public System.DateTime ghppottime;
        public System.DateTime elixirCPtime;
        public System.DateTime elixirHPtime;
        public System.DateTime smallcppottime;
        public System.DateTime qhptime;

    }

}
