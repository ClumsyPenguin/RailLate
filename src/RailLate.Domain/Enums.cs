namespace RailLate.Domain;

public static class Enums
{
    public enum PaymentMethodType
    {
        OnBoard,
        BeforeBoarding,
    }
    
    public enum DirectionType
    {
        OneDirection,
        OppositeDirection,
    }
    
    public enum WheelchairAccessibilityType
    {
        NoInformation,
        SomeAccessibility,
        NoAccessibility,
    }
    
    public enum PickupType
    {
        Regular,
        NoPickup,
        PhoneForPickup,
        DriverForPickup,
    }
    
    public enum DropOffType
    {
        Regular,
        NoPickup,
        PhoneForPickup,
        DriverForPickup,
    }
    
    public enum TimePointType
    {
        None,
        Approximate,
        Exact,
    }
    
    public enum LocationType
    {
        Stop,
        Station,
        EntranceExit,
        GenericNode,
        BoardingArea,
    }
    
    public enum IsBidirectional
    {
        Unidirectional,
        Bidirectional,
    }
    
    public enum PathwayMode
    {
        Walkway = 1,
        Stairs = 2,
        Travelator = 3,
        Escalator = 4,
        Elevator = 5,
        FareGate = 6,
        ExitGate = 7,
    }
    
    public enum TransferType
    {
        /// <summary>
        /// 0: This is a recommended transfer point between two routes.
        /// </summary>
        Recommended,
        /// <summary>
        /// 1: This is a timed transfer point between two routes. The departing vehicle is expected to wait for the arriving one, with sufficient time for a passenger to transfer between routes.
        /// </summary>
        TimedTransfer,
        /// <summary>
        /// 2: This transfer requires a minimum amount of time between arrival and departure to ensure a connection. The time required to transfer is specified by min_transfer_time.
        /// </summary>
        MinimumTime,
        /// <summary>
        /// 3: Transfers are not possible between routes at this location.
        /// </summary>
        NotPossible,
    }
    
    public enum RouteTypeExtended
  {
    /// <summary>RailwayService</summary>
    RailwayService = 100, // 0x00000064
    /// <summary>HighSpeedRailService</summary>
    HighSpeedRailService = 101, // 0x00000065
    /// <summary>LongDistanceTrains</summary>
    LongDistanceTrains = 102, // 0x00000066
    /// <summary>InterRegionalRailService</summary>
    InterRegionalRailService = 103, // 0x00000067
    /// <summary>CarTransportRailService</summary>
    CarTransportRailService = 104, // 0x00000068
    /// <summary>SleeperRailService</summary>
    SleeperRailService = 105, // 0x00000069
    /// <summary>RegionalRailService</summary>
    RegionalRailService = 106, // 0x0000006A
    /// <summary>TouristRailwayService</summary>
    TouristRailwayService = 107, // 0x0000006B
    /// <summary>RailShuttleWithinComplex</summary>
    RailShuttleWithinComplex = 108, // 0x0000006C
    /// <summary>SuburbanRailway</summary>
    SuburbanRailway = 109, // 0x0000006D
    /// <summary>ReplacementRailService</summary>
    ReplacementRailService = 110, // 0x0000006E
    /// <summary>SpecialRailService</summary>
    SpecialRailService = 111, // 0x0000006F
    /// <summary>LorryTransportRailService</summary>
    LorryTransportRailService = 112, // 0x00000070
    /// <summary>AllRailServices</summary>
    AllRailServices = 113, // 0x00000071
    /// <summary>CrossCountryRailService</summary>
    CrossCountryRailService = 114, // 0x00000072
    /// <summary>VehicleTransportRailService</summary>
    VehicleTransportRailService = 115, // 0x00000073
    /// <summary>RackandPinionRailway</summary>
    RackandPinionRailway = 116, // 0x00000074
    /// <summary>AdditionalRailService</summary>
    AdditionalRailService = 117, // 0x00000075
    /// <summary>CoachService</summary>
    CoachService = 200, // 0x000000C8
    /// <summary>InternationalCoachService</summary>
    InternationalCoachService = 201, // 0x000000C9
    /// <summary>NationalCoachService</summary>
    NationalCoachService = 202, // 0x000000CA
    /// <summary>ShuttleCoachService</summary>
    ShuttleCoachService = 203, // 0x000000CB
    /// <summary>RegionalCoachService</summary>
    RegionalCoachService = 204, // 0x000000CC
    /// <summary>SpecialCoachService</summary>
    SpecialCoachService = 205, // 0x000000CD
    /// <summary>SightseeingCoachService</summary>
    SightseeingCoachService = 206, // 0x000000CE
    /// <summary>TouristCoachService</summary>
    TouristCoachService = 207, // 0x000000CF
    /// <summary>CommuterCoachService</summary>
    CommuterCoachService = 208, // 0x000000D0
    /// <summary>AllCoachServices</summary>
    AllCoachServices = 209, // 0x000000D1
    /// <summary>SuburbanRailwayService</summary>
    SuburbanRailwayService = 300, // 0x0000012C
    /// <summary>UrbanRailwayService</summary>
    UrbanRailwayService = 400, // 0x00000190
    /// <summary>MetroCoachService</summary>
    MetroCoachService = 401, // 0x00000191
    /// <summary>UndergroundService</summary>
    UndergroundService = 402, // 0x00000192
    /// <summary>UrbanRailwayServiceDefault</summary>
    UrbanRailwayServiceDefault = 403, // 0x00000193
    /// <summary>AllUrbanRailwayServices</summary>
    AllUrbanRailwayServices = 404, // 0x00000194
    /// <summary>Monorail</summary>
    Monorail = 405, // 0x00000195
    /// <summary>MetroService</summary>
    MetroService = 500, // 0x000001F4
    /// <summary>UndergroundMetroService</summary>
    UndergroundMetroService = 600, // 0x00000258
    /// <summary>BusService</summary>
    BusService = 700, // 0x000002BC
    /// <summary>RegionalBusService</summary>
    RegionalBusService = 701, // 0x000002BD
    /// <summary>ExpressBusService</summary>
    ExpressBusService = 702, // 0x000002BE
    /// <summary>StoppingBusService</summary>
    StoppingBusService = 703, // 0x000002BF
    /// <summary>LocalBusService</summary>
    LocalBusService = 704, // 0x000002C0
    /// <summary>NightBusService</summary>
    NightBusService = 705, // 0x000002C1
    /// <summary>PostBusService</summary>
    PostBusService = 706, // 0x000002C2
    /// <summary>SpecialNeedsBus</summary>
    SpecialNeedsBus = 707, // 0x000002C3
    /// <summary>MobilityBusService</summary>
    MobilityBusService = 708, // 0x000002C4
    /// <summary>MobilityBusforRegisteredDisabled</summary>
    MobilityBusforRegisteredDisabled = 709, // 0x000002C5
    /// <summary>SightseeingBus</summary>
    SightseeingBus = 710, // 0x000002C6
    /// <summary>ShuttleBus</summary>
    ShuttleBus = 711, // 0x000002C7
    /// <summary>SchoolBus</summary>
    SchoolBus = 712, // 0x000002C8
    /// <summary>SchoolandPublicServiceBus</summary>
    SchoolandPublicServiceBus = 713, // 0x000002C9
    /// <summary>RailReplacementBusService</summary>
    RailReplacementBusService = 714, // 0x000002CA
    /// <summary>DemandandResponseBusService</summary>
    DemandandResponseBusService = 715, // 0x000002CB
    /// <summary>AllBusServices</summary>
    AllBusServices = 716, // 0x000002CC
    /// <summary>ShareTaxiService</summary>
    ShareTaxiService = 717, // 0x000002CD
    /// <summary>TrolleybusService</summary>
    TrolleybusService = 800, // 0x00000320
    /// <summary>TramService</summary>
    TramService = 900, // 0x00000384
    /// <summary>CityTramService</summary>
    CityTramService = 901, // 0x00000385
    /// <summary>LocalTramService</summary>
    LocalTramService = 902, // 0x00000386
    /// <summary>RegionalTramService</summary>
    RegionalTramService = 903, // 0x00000387
    /// <summary>SightseeingTramService</summary>
    SightseeingTramService = 904, // 0x00000388
    /// <summary>ShuttleTramService</summary>
    ShuttleTramService = 905, // 0x00000389
    /// <summary>AllTramServices</summary>
    AllTramServices = 906, // 0x0000038A
    /// <summary>WaterTransportService</summary>
    WaterTransportService = 1000, // 0x000003E8
    /// <summary>InternationalCarFerryService</summary>
    InternationalCarFerryService = 1001, // 0x000003E9
    /// <summary>NationalCarFerryService</summary>
    NationalCarFerryService = 1002, // 0x000003EA
    /// <summary>RegionalCarFerryService</summary>
    RegionalCarFerryService = 1003, // 0x000003EB
    /// <summary>LocalCarFerryService</summary>
    LocalCarFerryService = 1004, // 0x000003EC
    /// <summary>InternationalPassengerFerryService</summary>
    InternationalPassengerFerryService = 1005, // 0x000003ED
    /// <summary>NationalPassengerFerryService</summary>
    NationalPassengerFerryService = 1006, // 0x000003EE
    /// <summary>RegionalPassengerFerryService</summary>
    RegionalPassengerFerryService = 1007, // 0x000003EF
    /// <summary>LocalPassengerFerryService</summary>
    LocalPassengerFerryService = 1008, // 0x000003F0
    /// <summary>PostBoatService</summary>
    PostBoatService = 1009, // 0x000003F1
    /// <summary>TrainFerryService</summary>
    TrainFerryService = 1010, // 0x000003F2
    /// <summary>RoadLinkFerryService</summary>
    RoadLinkFerryService = 1011, // 0x000003F3
    /// <summary>AirportLinkFerryService</summary>
    AirportLinkFerryService = 1012, // 0x000003F4
    /// <summary>CarHighSpeedFerryService</summary>
    CarHighSpeedFerryService = 1013, // 0x000003F5
    /// <summary>PassengerHighSpeedFerryService</summary>
    PassengerHighSpeedFerryService = 1014, // 0x000003F6
    /// <summary>SightseeingBoatService</summary>
    SightseeingBoatService = 1015, // 0x000003F7
    /// <summary>SchoolBoat</summary>
    SchoolBoat = 1016, // 0x000003F8
    /// <summary>CableDrawnBoatService</summary>
    CableDrawnBoatService = 1017, // 0x000003F9
    /// <summary>RiverBusService</summary>
    RiverBusService = 1018, // 0x000003FA
    /// <summary>ScheduledFerryService</summary>
    ScheduledFerryService = 1019, // 0x000003FB
    /// <summary>ShuttleFerryService</summary>
    ShuttleFerryService = 1020, // 0x000003FC
    /// <summary>AllWaterTransportServices</summary>
    AllWaterTransportServices = 1021, // 0x000003FD
    /// <summary>AirService</summary>
    AirService = 1100, // 0x0000044C
    /// <summary>InternationalAirService</summary>
    InternationalAirService = 1101, // 0x0000044D
    /// <summary>DomesticAirService</summary>
    DomesticAirService = 1102, // 0x0000044E
    /// <summary>IntercontinentalAirService</summary>
    IntercontinentalAirService = 1103, // 0x0000044F
    /// <summary>DomesticScheduledAirService</summary>
    DomesticScheduledAirService = 1104, // 0x00000450
    /// <summary>ShuttleAirService</summary>
    ShuttleAirService = 1105, // 0x00000451
    /// <summary>IntercontinentalCharterAirService</summary>
    IntercontinentalCharterAirService = 1106, // 0x00000452
    /// <summary>InternationalCharterAirService</summary>
    InternationalCharterAirService = 1107, // 0x00000453
    /// <summary>RoundTripCharterAirService</summary>
    RoundTripCharterAirService = 1108, // 0x00000454
    /// <summary>SightseeingAirService</summary>
    SightseeingAirService = 1109, // 0x00000455
    /// <summary>HelicopterAirService</summary>
    HelicopterAirService = 1110, // 0x00000456
    /// <summary>DomesticCharterAirService</summary>
    DomesticCharterAirService = 1111, // 0x00000457
    /// <summary>SchengenAreaAirService</summary>
    SchengenAreaAirService = 1112, // 0x00000458
    /// <summary>AirshipService</summary>
    AirshipService = 1113, // 0x00000459
    /// <summary>AllAirServices</summary>
    AllAirServices = 1114, // 0x0000045A
    /// <summary>FerryService</summary>
    FerryService = 1200, // 0x000004B0
    /// <summary>TelecabinService</summary>
    TelecabinService = 1300, // 0x00000514
    /// <summary>TelecabinServiceDefault</summary>
    TelecabinServiceDefault = 1301, // 0x00000515
    /// <summary>TelecabinServiceDefault</summary>
    CableCarService = 1302, // 0x00000516
    /// <summary>ElevatorService</summary>
    ElevatorService = 1303, // 0x00000517
    /// <summary>ChairLiftService</summary>
    ChairLiftService = 1304, // 0x00000518
    /// <summary>DragLiftService</summary>
    DragLiftService = 1305, // 0x00000519
    /// <summary>SmallTelecabinService</summary>
    SmallTelecabinService = 1306, // 0x0000051A
    /// <summary>AllTelecabinServices</summary>
    AllTelecabinServices = 1307, // 0x0000051B
    /// <summary>FunicularService</summary>
    FunicularService = 1400, // 0x00000578
    /// <summary>FunicularServiceDefault</summary>
    FunicularServiceDefault = 1401, // 0x00000579
    /// <summary>AllFunicularService</summary>
    AllFunicularService = 1402, // 0x0000057A
    /// <summary>TaxiService</summary>
    TaxiService = 1500, // 0x000005DC
    /// <summary>CommunalTaxiService</summary>
    CommunalTaxiService = 1501, // 0x000005DD
    /// <summary>WaterTaxiService</summary>
    WaterTaxiService = 1502, // 0x000005DE
    /// <summary>RailTaxiService</summary>
    RailTaxiService = 1503, // 0x000005DF
    /// <summary>BikeTaxiService</summary>
    BikeTaxiService = 1504, // 0x000005E0
    /// <summary>LicensedTaxiService</summary>
    LicensedTaxiService = 1505, // 0x000005E1
    /// <summary>PrivateHireServiceVehicle</summary>
    PrivateHireServiceVehicle = 1506, // 0x000005E2
    /// <summary>AllTaxiServices</summary>
    AllTaxiServices = 1507, // 0x000005E3
    /// <summary>SelfDrive</summary>
    SelfDrive = 1600, // 0x00000640
    /// <summary>HireCar</summary>
    HireCar = 1601, // 0x00000641
    /// <summary>HireVan</summary>
    HireVan = 1602, // 0x00000642
    /// <summary>HireMotorbike</summary>
    HireMotorbike = 1603, // 0x00000643
    /// <summary>HireCycle</summary>
    HireCycle = 1604, // 0x00000644
    /// <summary>MiscellaneousService</summary>
    MiscellaneousService = 1700, // 0x000006A4
    /// <summary>CableCar</summary>
    CableCar = 1701, // 0x000006A5
    /// <summary>HorsedrawnCarriage</summary>
    HorsedrawnCarriage = 1702, // 0x000006A6
  }
}