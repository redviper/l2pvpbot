using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace l2pvp
{
    public class CharInfo
    {
        private readonly object AbnormalEffectsLock;
        private readonly object AllyCrestIDLock;
        private readonly object AllyIDLock;
        private readonly object AttackSpeedMultLock;
        private readonly object BackLock;
        private readonly object ChestLock;
        private readonly object ClanCrestIDLargeLock;
        private readonly object ClanCrestIDLock;
        private readonly object ClanIDLock;
        private readonly object ClassLock;
        private readonly object CollisionHeightLock;
        private readonly object CollisionRadiusLock;
        private readonly object CubicCountLock;
        private readonly object CubicsLock;
        private readonly object Cur_CPLock;
        private readonly object Cur_HPLock;
        private readonly object Cur_MPLock;
        private readonly object CurCPLock;
        private readonly object DemonSwordLock;
        private readonly object Dest_XLock;
        private readonly object Dest_YLock;
        private readonly object Dest_ZLock;
        private readonly object DollFaceLock;
        private readonly object EnchantAmountLock;
        private readonly object FaceLock;
        private readonly object FeetLock;
        private readonly object FindPartyLock;
        private readonly object FishXLock;
        private readonly object FishYLock;
        private readonly object FishZLock;
        private readonly object flRunSpeedLock;
        private readonly object flWalkSpeedLock;
        private readonly object FlyRunSpeedLock;
        private readonly object FlyWalkSpeedLock;
        private readonly object GlovesLock;
        private readonly object HairColorLock;
        private readonly object HairLock;
        private readonly object HairSytleLock;
        private readonly object HeadingLock;
        private readonly object HeadLock;
        private readonly object HeroGlowLock;
        private readonly object HeroIconLock;
        private readonly object IDLock;
        private readonly object InvisibleLock;
        private readonly object isAlikeDeadLock;
        private readonly object isFishingLock;
        private readonly object isInCombatLock;
        private readonly object isRunningLock;
        private readonly object isSittingLock;
        private readonly object Karma2Lock;
        private readonly object KarmaLock;
        private readonly object lastMoveTimeLock;
        private readonly object LegsLock;
        private readonly object LevelLock;
        private readonly object LHandLock;
        private readonly object LRHandLock;
        private readonly object MatkSpeedLock;
        private readonly object Max_CPLock;
        private readonly object Max_HPLock;
        private readonly object Max_MPLock;
        private readonly object MaxCPLock;
        private readonly object MountTypeLock;
        private readonly object MoveSpeedMultLock;
        private readonly object MoveTargetLock;
        private readonly object MoveTargetTypeLock;
        private readonly object MovingLock;
        private readonly object my_buffsLock;
        private readonly object NameColorLock;
        private readonly object NameLock;
        private readonly object PatkSpeedLock;
        private readonly object PledgeClassLock;
        private readonly object PrivateStoreTypeLock;
        private readonly object PvPFlag2Lock;
        private readonly object PvPFlagLock;
        private readonly object RaceLock;
        private readonly object RecAmountLock;
        private readonly object RecLeftLock;
        private readonly object RHandLock;
        private readonly object RunSpeedLock;
        private readonly object SexLock;
        private readonly object SiegeFlagsLock;
        private readonly object SwimRunSpeedLock;
        private readonly object SwimWalkSpeedLock;
        private readonly object TargetIDLock;
        private readonly object TargetTypeLock;
        private readonly object TeamCircleLock;
        private readonly object TitleColorLock;
        private readonly object TitleLock;
        private readonly object UnderwearLock;
        private readonly object UNKNOWN1Lock;
        private readonly object UNKNOWN2Lock;
        private readonly object UNKNOWN3Lock;
        private readonly object WalkSpeedLock;
        private readonly object WarStateLock;
        private readonly object XLock;
        private readonly object YLock;
        private readonly object ZLock;

        private uint _AbnormalEffects;
        private uint _AllyCrestID;
        private uint _AllyID;
        private double _AttackSpeedMult;
        private uint _Back;
        private uint _Chest;
        private uint _ClanCrestID;
        private uint _ClanCrestIDLarge;
        private uint _ClanID;
        private uint _Class;
        private double _CollisionHeight;
        private double _CollisionRadius;
        private ushort _CubicCount;
        private ArrayList _Cubics;
        private uint _Cur_CP;
        private uint _Cur_HP;
        private uint _Cur_MP;
        private uint _DemonSword;
        private int _Dest_X;
        private int _Dest_Y;
        private int _Dest_Z;
        private uint _DollFace;
        private byte _EnchantAmount;
        private uint _Face;
        private uint _Feet;
        private byte _FindParty;
        private int _FishX;
        private int _FishY;
        private int _FishZ;
        private uint _flRunSpeed;
        private uint _flWalkSpeed;
        private uint _FlyRunSpeed;
        private uint _FlyWalkSpeed;
        private uint _Gloves;
        private uint _Hair;
        private uint _HairColor;
        private uint _HairSytle;
        private uint _Head;
        private int _Heading;
        private byte _HeroGlow;
        private byte _HeroIcon;
        private uint _ID;
        private byte _Invisible;
        private byte _isAlikeDead;
        private byte _isFishing;
        private byte _isInCombat;
        private byte _isRunning;
        private byte _isSitting;
        private uint _Karma;
        private uint _Karma2;
        private DateTime _lastMoveTime;
        private uint _Legs;
        private uint _Level;
        private uint _LHand;
        private uint _LRHand;
        private uint _MatkSpeed;
        private uint _Max_CP;
        private uint _Max_HP;
        private uint _Max_MP;
        private byte _MountType;
        private double _MoveSpeedMult;
        private uint _MoveTarget;
        private int _MoveTargetType;
        private bool _Moving;
        private string _Name;
        private uint _NameColor;
        private uint _PatkSpeed;
        private uint _PledgeClass;
        private byte _PrivateStoreType;
        private uint _PvPFlag;
        private uint _PvPFlag2;
        private uint _Race;
        private ushort _RecAmount;
        private byte _RecLeft;
        private uint _RHand;
        private uint _RunSpeed;
        private uint _Sex;
        private uint _SiegeFlags;
        private uint _SwimRunSpeed;
        private uint _SwimWalkSpeed;
        private uint _TargetID;
        private int _TargetType;
        private byte _TeamCircle;
        private string _Title;
        private uint _TitleColor;
        private uint _Underwear;
        private uint _UNKNOWN1;
        private uint _UNKNOWN2;
        private uint _UNKNOWN3;
        private uint _WalkSpeed;
        private uint _WarState;
        private int _X;
        private int _Y;
        private int _Z;

        public int relation = 0;

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

        public uint Back
        {
            get
            {
                uint ui;

                lock (BackLock)
                {
                    ui = _Back;
                }
                return ui;
            }
            set
            {
                lock (BackLock)
                {
                    _Back = value;
                }
            }
        }

        public uint Chest
        {
            get
            {
                uint ui;

                lock (ChestLock)
                {
                    ui = _Chest;
                }
                return ui;
            }
            set
            {
                lock (ChestLock)
                {
                    _Chest = value;
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

        public uint Cur_CP
        {
            get
            {
                uint ui;

                lock (Cur_CPLock)
                {
                    ui = _Cur_CP;
                }
                return ui;
            }
            set
            {
                lock (Cur_CPLock)
                {
                    _Cur_CP = value;
                }
            }
        }

        public uint Cur_HP
        {
            get
            {
                uint ui;

                lock (Cur_HPLock)
                {
                    ui = _Cur_HP;
                }
                return ui;
            }
            set
            {
                lock (Cur_HPLock)
                {
                    _Cur_HP = value;
                }
            }
        }

        public uint Cur_MP
        {
            get
            {
                uint ui;

                lock (Cur_MPLock)
                {
                    ui = _Cur_MP;
                }
                return ui;
            }
            set
            {
                lock (Cur_MPLock)
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

                lock (Dest_XLock)
                {
                    i = _Dest_X;
                }
                return i;
            }
            set
            {
                lock (Dest_XLock)
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

                lock (Dest_YLock)
                {
                    i = _Dest_Y;
                }
                return i;
            }
            set
            {
                lock (Dest_YLock)
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

                lock (Dest_ZLock)
                {
                    i = _Dest_Z;
                }
                return i;
            }
            set
            {
                lock (Dest_ZLock)
                {
                    _Dest_Z = value;
                }
            }
        }

        public uint DollFace
        {
            get
            {
                uint ui;

                lock (DollFaceLock)
                {
                    ui = _DollFace;
                }
                return ui;
            }
            set
            {
                lock (DollFaceLock)
                {
                    _DollFace = value;
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

        public uint Feet
        {
            get
            {
                uint ui;

                lock (FeetLock)
                {
                    ui = _Feet;
                }
                return ui;
            }
            set
            {
                lock (FeetLock)
                {
                    _Feet = value;
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

        public uint Gloves
        {
            get
            {
                uint ui;

                lock (GlovesLock)
                {
                    ui = _Gloves;
                }
                return ui;
            }
            set
            {
                lock (GlovesLock)
                {
                    _Gloves = value;
                }
            }
        }

        public uint Hair
        {
            get
            {
                uint ui;

                lock (HairLock)
                {
                    ui = _Hair;
                }
                return ui;
            }
            set
            {
                lock (HairLock)
                {
                    _Hair = value;
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

        public uint Head
        {
            get
            {
                uint ui;

                lock (HeadLock)
                {
                    ui = _Head;
                }
                return ui;
            }
            set
            {
                lock (HeadLock)
                {
                    _Head = value;
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

        public uint ID
        {
            get
            {
                uint ui;

                lock (IDLock)
                {
                    ui = _ID;
                }
                return ui;
            }
            set
            {
                lock (IDLock)
                {
                    _ID = value;
                }
            }
        }

        public byte Invisible
        {
            get
            {
                byte b;

                lock (InvisibleLock)
                {
                    b = _Invisible;
                }
                return b;
            }
            set
            {
                lock (InvisibleLock)
                {
                    _Invisible = value;
                }
            }
        }

        public byte isAlikeDead
        {
            get
            {
                byte b;

                lock (isAlikeDeadLock)
                {
                    b = _isAlikeDead;
                }
                return b;
            }
            set
            {
                lock (isAlikeDeadLock)
                {
                    _isAlikeDead = value;
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

        public byte isInCombat
        {
            get
            {
                byte b;

                lock (isInCombatLock)
                {
                    b = _isInCombat;
                }
                return b;
            }
            set
            {
                lock (isInCombatLock)
                {
                    _isInCombat = value;
                }
            }
        }

        public byte isRunning
        {
            get
            {
                byte b;

                lock (isRunningLock)
                {
                    b = _isRunning;
                }
                return b;
            }
            set
            {
                lock (isRunningLock)
                {
                    _isRunning = value;
                }
            }
        }

        public byte isSitting
        {
            get
            {
                byte b;

                lock (isSittingLock)
                {
                    b = _isSitting;
                }
                return b;
            }
            set
            {
                lock (isSittingLock)
                {
                    _isSitting = value;
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

        public uint Karma2
        {
            get
            {
                uint ui;

                lock (Karma2Lock)
                {
                    ui = _Karma2;
                }
                return ui;
            }
            set
            {
                lock (Karma2Lock)
                {
                    _Karma2 = value;
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

        public uint Legs
        {
            get
            {
                uint ui;

                lock (LegsLock)
                {
                    ui = _Legs;
                }
                return ui;
            }
            set
            {
                lock (LegsLock)
                {
                    _Legs = value;
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

        public uint LHand
        {
            get
            {
                uint ui;

                lock (LHandLock)
                {
                    ui = _LHand;
                }
                return ui;
            }
            set
            {
                lock (LHandLock)
                {
                    _LHand = value;
                }
            }
        }

        public uint LRHand
        {
            get
            {
                uint ui;

                lock (LRHandLock)
                {
                    ui = _LRHand;
                }
                return ui;
            }
            set
            {
                lock (LRHandLock)
                {
                    _LRHand = value;
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

        public uint Max_CP
        {
            get
            {
                uint ui;

                lock (Max_CPLock)
                {
                    ui = _Max_CP;
                }
                return ui;
            }
            set
            {
                lock (Max_CPLock)
                {
                    _Max_CP = value;
                }
            }
        }

        public uint Max_HP
        {
            get
            {
                uint ui;

                lock (Max_HPLock)
                {
                    ui = _Max_HP;
                }
                return ui;
            }
            set
            {
                lock (Max_HPLock)
                {
                    _Max_HP = value;
                }
            }
        }

        public uint Max_MP
        {
            get
            {
                uint ui;

                lock (Max_MPLock)
                {
                    ui = _Max_MP;
                }
                return ui;
            }
            set
            {
                lock (Max_MPLock)
                {
                    _Max_MP = value;
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

                lock (MovingLock)
                {
                    flag = _Moving;
                }
                return flag;
            }
            set
            {
                lock (MovingLock)
                {
                    _Moving = value;
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

        public uint PvPFlag2
        {
            get
            {
                uint ui;

                lock (PvPFlag2Lock)
                {
                    ui = _PvPFlag2;
                }
                return ui;
            }
            set
            {
                lock (PvPFlag2Lock)
                {
                    _PvPFlag2 = value;
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

        public byte RecLeft
        {
            get
            {
                byte b;

                lock (RecLeftLock)
                {
                    b = _RecLeft;
                }
                return b;
            }
            set
            {
                lock (RecLeftLock)
                {
                    _RecLeft = value;
                }
            }
        }

        public uint RHand
        {
            get
            {
                uint ui;

                lock (RHandLock)
                {
                    ui = _RHand;
                }
                return ui;
            }
            set
            {
                lock (RHandLock)
                {
                    _RHand = value;
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

        public uint SiegeFlags
        {
            get
            {
                uint ui;

                lock (SiegeFlagsLock)
                {
                    ui = _SiegeFlags;
                }
                return ui;
            }
            set
            {
                lock (SiegeFlagsLock)
                {
                    _SiegeFlags = value;
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

        public uint TargetID
        {
            get
            {
                uint ui;

                lock (TargetIDLock)
                {
                    ui = _TargetID;
                }
                return ui;
            }
            set
            {
                lock (TargetIDLock)
                {
                    _TargetID = value;
                }
            }
        }

        public int TargetType
        {
            get
            {
                int i;

                lock (TargetTypeLock)
                {
                    i = _TargetType;
                }
                return i;
            }
            set
            {
                lock (TargetTypeLock)
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

        public uint Underwear
        {
            get
            {
                uint ui;

                lock (UnderwearLock)
                {
                    ui = _Underwear;
                }
                return ui;
            }
            set
            {
                lock (UnderwearLock)
                {
                    _Underwear = value;
                }
            }
        }

        public uint UNKNOWN1
        {
            get
            {
                uint ui;

                lock (UNKNOWN1Lock)
                {
                    ui = _UNKNOWN1;
                }
                return ui;
            }
            set
            {
                lock (UNKNOWN1Lock)
                {
                    _UNKNOWN1 = value;
                }
            }
        }

        public uint UNKNOWN2
        {
            get
            {
                uint ui;

                lock (UNKNOWN2Lock)
                {
                    ui = _UNKNOWN2;
                }
                return ui;
            }
            set
            {
                lock (UNKNOWN2Lock)
                {
                    _UNKNOWN2 = value;
                }
            }
        }

        public uint UNKNOWN3
        {
            get
            {
                uint ui;

                lock (UNKNOWN3Lock)
                {
                    ui = _UNKNOWN3;
                }
                return ui;
            }
            set
            {
                lock (UNKNOWN3Lock)
                {
                    _UNKNOWN3 = value;
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

        public uint WarState
        {
            get
            {
                uint ui;

                lock (WarStateLock)
                {
                    ui = _WarState;
                }
                return ui;
            }
            set
            {
                lock (WarStateLock)
                {
                    _WarState = value;
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

        public CharInfo()
        {
            _WarState = 0;
            _Cur_HP = 0;
            _Max_HP = 0;
            _Cur_MP = 0;
            _Max_MP = 0;
            _Cur_CP = 0;
            _Max_CP = 0;
            my_buffsLock = new Object();
            Max_CPLock = new Object();
            Cur_CPLock = new Object();
            Max_MPLock = new Object();
            Cur_MPLock = new Object();
            Max_HPLock = new Object();
            Cur_HPLock = new Object();
            TargetTypeLock = new Object();
            TargetIDLock = new Object();
            MoveTargetTypeLock = new Object();
            MoveTargetLock = new Object();
            lastMoveTimeLock = new Object();
            MovingLock = new Object();
            Dest_ZLock = new Object();
            Dest_YLock = new Object();
            Dest_XLock = new Object();
            WarStateLock = new Object();
            ZLock = new Object();
            YLock = new Object();
            XLock = new Object();
            NameColorLock = new Object();
            FishZLock = new Object();
            FishYLock = new Object();
            FishXLock = new Object();
            isFishingLock = new Object();
            HeroGlowLock = new Object();
            HeroIconLock = new Object();
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
            ClanCrestIDLargeLock = new Object();
            EnchantAmountLock = new Object();
            RecAmountLock = new Object();
            TeamCircleLock = new Object();
            CurCPLock = new Object();
            MaxCPLock = new Object();
            UNKNOWN1Lock = new Object();
            UNKNOWN2Lock = new Object();
            UNKNOWN3Lock = new Object();
            RecLeftLock = new Object();
            AbnormalEffectsLock = new Object();
            FindPartyLock = new Object();
            CubicsLock = new Object();
            CubicCountLock = new Object();
            PrivateStoreTypeLock = new Object();
            MountTypeLock = new Object();
            InvisibleLock = new Object();
            isAlikeDeadLock = new Object();
            isInCombatLock = new Object();
            isRunningLock = new Object();
            isSittingLock = new Object();
            SiegeFlagsLock = new Object();
            AllyCrestIDLock = new Object();
            AllyIDLock = new Object();
            ClanCrestIDLock = new Object();
            ClanIDLock = new Object();
            TitleLock = new Object();
            FaceLock = new Object();
            HairColorLock = new Object();
            HairSytleLock = new Object();
            Karma2Lock = new Object();
            PvPFlag2Lock = new Object();
            PatkSpeedLock = new Object();
            MatkSpeedLock = new Object();
            KarmaLock = new Object();
            PvPFlagLock = new Object();
            HairLock = new Object();
            DollFaceLock = new Object();
            LRHandLock = new Object();
            BackLock = new Object();
            FeetLock = new Object();
            LegsLock = new Object();
            ChestLock = new Object();
            GlovesLock = new Object();
            LHandLock = new Object();
            RHandLock = new Object();
            HeadLock = new Object();
            UnderwearLock = new Object();
            ClassLock = new Object();
            SexLock = new Object();
            RaceLock = new Object();
            NameLock = new Object();
            IDLock = new Object();
            HeadingLock = new Object();
            LevelLock = new Object();
            TitleColorLock = new Object();
            PledgeClassLock = new Object();
            DemonSwordLock = new Object();
            Moving = false;
            peace = 0;
        }

        public uint FaceInv;
        public uint RHand2;
        public uint RLHand;

        public void Load(ByteBuffer buff)
        {
            X = buff.ReadInt32();
            Y = buff.ReadInt32();
            Z = buff.ReadInt32();
            Heading = buff.ReadInt32();
            ID = buff.ReadUInt32();
            Name = buff.ReadString();
            Race = buff.ReadUInt32();
            Sex = buff.ReadUInt32();
            Class = buff.ReadUInt32();
            Underwear = buff.ReadUInt32();
            Head = buff.ReadUInt32();
            RHand = buff.ReadUInt32();
            LHand = buff.ReadUInt32();
            Gloves = buff.ReadUInt32();
            Chest = buff.ReadUInt32();
            Legs = buff.ReadUInt32();
            Feet = buff.ReadUInt32();
            Back = buff.ReadUInt32();
            LRHand = buff.ReadUInt32();
            Hair = buff.ReadUInt32();
            FaceInv = buff.ReadUInt32();
            for (int i = 0; i < 8; i++)
                buff.ReadUInt32();
            for (int i = 0; i < 4; i++)
                buff.ReadUInt16();
            RHand2 = buff.ReadUInt32();
            for (int i = 0; i < 12; i++)
                buff.ReadUInt16();
            RLHand = buff.ReadUInt32();
            for (int i = 0; i < 4; i++)
                buff.ReadUInt16();
            for (int i = 0; i < 16; i++)
                buff.ReadUInt16();
            PvPFlag = buff.ReadUInt32();
            Karma = buff.ReadUInt32();
            MatkSpeed = buff.ReadUInt32();
            PatkSpeed = buff.ReadUInt32();
            PvPFlag2 = buff.ReadUInt32();
            Karma2 = buff.ReadUInt32();
            RunSpeed = buff.ReadUInt32();
            WalkSpeed = buff.ReadUInt32();
            SwimRunSpeed = buff.ReadUInt32();
            SwimWalkSpeed = buff.ReadUInt32();
            flRunSpeed = buff.ReadUInt32();
            flWalkSpeed = buff.ReadUInt32();
            FlyRunSpeed = buff.ReadUInt32();
            FlyWalkSpeed = buff.ReadUInt32();
            MoveSpeedMult = buff.ReadDouble();
            AttackSpeedMult = buff.ReadDouble();
            CollisionRadius = buff.ReadDouble();
            CollisionHeight = buff.ReadDouble();
            HairSytle = buff.ReadUInt32();
            HairColor = buff.ReadUInt32();
            Face = buff.ReadUInt32();
            Title = buff.ReadString();
            ClanID = buff.ReadUInt32();
            ClanCrestID = buff.ReadUInt32();
            AllyID = buff.ReadUInt32();
            AllyCrestID = buff.ReadUInt32();
            SiegeFlags = buff.ReadUInt32();
            isSitting = buff.ReadByte();
            isRunning = buff.ReadByte();
            isInCombat = buff.ReadByte();
            isAlikeDead = buff.ReadByte();
            Invisible = buff.ReadByte();
            MountType = buff.ReadByte();
            PrivateStoreType = buff.ReadByte();
            CubicCount = buff.ReadUInt16();
            Cubics = new ArrayList();
            for (int i = 0; (ushort)i < CubicCount; i++)
            {
                ushort ush = buff.ReadUInt16();
                Cubics.Add(ush);
            }
            FindParty = buff.ReadByte();
            AbnormalEffects = buff.ReadUInt32();
            RecLeft = buff.ReadByte();
            RecAmount = buff.ReadUInt16();
            UNKNOWN3 = buff.ReadUInt32();
            Max_CP = buff.ReadUInt32();
            Cur_CP = buff.ReadUInt32();
            EnchantAmount = buff.ReadByte();
            TeamCircle = buff.ReadByte();
            ClanCrestIDLarge = buff.ReadUInt32();
            HeroIcon = buff.ReadByte();
            HeroGlow = buff.ReadByte();
            isFishing = buff.ReadByte();
            FishX = buff.ReadInt32();
            FishY = buff.ReadInt32();
            FishZ = buff.ReadInt32();
            NameColor = buff.ReadUInt32();
            UNKNOWN1 = buff.ReadUInt32();
            PledgeClass = buff.ReadUInt32();
            UNKNOWN2 = buff.ReadUInt32();
            TitleColor = buff.ReadUInt32();
            UNKNOWN3 = buff.ReadUInt32();
            DemonSword = buff.ReadUInt32();
//            Console.WriteLine("Char {0} has status effect {1}", Name, AbnormalEffects);
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
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 13:
                case 14:
                case 15:
                case 0x10:
                case 0x11:
                case 0x13:
                case 20:
                case 0x15:
                case 0x16:
                case 0x17:
                case 0x19:
                case 0x1c:
                case 0x1d:
                case 30:
                case 0x1f:
                case 0x20:
                    return;

                case 9:
                    this.Cur_HP = num2;
                    if (this.Cur_HP > 1)
                    {
                        isAlikeDead = 0;
                    }
                    if (this.Cur_HP < 1)
                    {
                        isAlikeDead = 1;
                    }
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

                case 0x12:
                    this.PatkSpeed = num2;
                    return;

                case 0x18:
                    this.MatkSpeed = num2;
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

        public override string ToString()
        {
            return _Name;
        }
        public double distance;
        public int peace;
        public int rauto;
        public int rkarma;
        public int rpvpflag;


    } // class CharInfo

}
