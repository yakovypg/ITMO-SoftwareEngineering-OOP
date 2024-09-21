using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Infrastructure;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class Tests
{
    [Fact]
    public void CorrectAssemblyFromCompatibleComponents()
    {
        Cpu cpu = new CpuEngineer(new CpuBuilder()).ManufactureIntelCoreI58400();
        Gpu gpu = new GpuEngineer(new GpuBuilder()).ManufactureGeForceRTX2060();
        Ram ram = new RamEngineer(new RamBuilder()).ManufactureKingstonFury();

        Motherboard motherboard = new MotherboardEngineer(
            new MotherboardBuilder()).ManufactureASRockH310CMDVS();

        CpuCoolingSystem coolingSystem = new CpuCoolingSystemEngineer(
            new CpuCoolingSystemBuilder()).ManufactureDeepCoolAK620();

        ComputerCase computerCase = new ComputerCaseEngineer(
            new ComputerCaseBuilder()).ManufactureStandardCase();

        PowerSupply powerSupply = new PowerSupplyEngineer(
            new PowerSupplyBuilder()).ManufactureCougarBXM1200();

        SsdDrive ssd = new SsdDriveEngineer(
            new SsdDriveBuilder()).ManufactureApacerAS350Panther();

        HardDisk hardDisk = new HardDiskEngineer(
            new HardDiskBuilder()).ManufactureSeagateBarraCuda();

        ComputerComponentsService.Repository.AddMotherboard(motherboard);
        ComputerComponentsService.Repository.AddCpu(cpu);
        ComputerComponentsService.Repository.AddCoolingSystem(coolingSystem);
        ComputerComponentsService.Repository.AddPowerSupply(powerSupply);
        ComputerComponentsService.Repository.AddGpu(gpu);
        ComputerComponentsService.Repository.AddRam(ram);
        ComputerComponentsService.Repository.AddHardDisk(hardDisk);
        ComputerComponentsService.Repository.AddSsdDrive(ssd);
        ComputerComponentsService.Repository.AddComputerCase(computerCase);

        Computer computer = new ComputerConstructor()
            .AddMotherboard(motherboard)
            .AddCpu(cpu)
            .AddCoolingSystem(coolingSystem)
            .AddPowerSupply(powerSupply)
            .AddGpu(gpu)
            .AddRam(ram)
            .AddHardDisk(hardDisk)
            .AddSsdDrive(ssd)
            .AddCase(computerCase)
            .Build();

        Order order = OrderService.CreateOrder(computer);

        Assert.True(order.IsPowerRecommendationFollowed);
        Assert.False(order.HasNotRecommendedComponentsCombinations);
        Assert.False(order.DisclaimerOfWarranty);
    }

    [Fact]
    public void AssemblyWithDisclaimerOfWarranty()
    {
        Cpu cpu = new CpuEngineer(new CpuBuilder()).ManufactureIntelCoreI58400();
        Gpu gpu = new GpuEngineer(new GpuBuilder()).ManufactureGeForceRTX2060();
        Ram ram = new RamEngineer(new RamBuilder()).ManufactureKingstonFury();

        Motherboard motherboard = new MotherboardEngineer(
            new MotherboardBuilder()).ManufactureASRockH310CMDVS();

        CpuCoolingSystem coolingSystem = new CpuCoolingSystemEngineer(
            new CpuCoolingSystemBuilder()).ManufactureCoolTY50();

        ComputerCase computerCase = new ComputerCaseEngineer(
            new ComputerCaseBuilder()).ManufactureStandardCase();

        PowerSupply powerSupply = new PowerSupplyEngineer(
            new PowerSupplyBuilder()).ManufactureCougarBXM1200();

        var ssdEngineer = new SsdDriveEngineer(new SsdDriveBuilder());
        SsdDrive ssd1 = ssdEngineer.ManufactureApacerAS350Panther();
        SsdDrive ssd2 = ssdEngineer.ManufactureApacerAS350Panther();

        ComputerComponentsService.Repository.AddMotherboard(motherboard);
        ComputerComponentsService.Repository.AddCpu(cpu);
        ComputerComponentsService.Repository.AddCoolingSystem(coolingSystem);
        ComputerComponentsService.Repository.AddPowerSupply(powerSupply);
        ComputerComponentsService.Repository.AddGpu(gpu);
        ComputerComponentsService.Repository.AddRam(ram);
        ComputerComponentsService.Repository.AddSsdDrive(ssd1);
        ComputerComponentsService.Repository.AddSsdDrive(ssd2);
        ComputerComponentsService.Repository.AddComputerCase(computerCase);

        Computer computer = new ComputerConstructor()
            .AddMotherboard(motherboard)
            .AddCpu(cpu)
            .AddCoolingSystem(coolingSystem)
            .AddPowerSupply(powerSupply)
            .AddGpu(gpu)
            .AddRam(ram)
            .AddSsdDrive(ssd1)
            .AddSsdDrive(ssd2)
            .AddCase(computerCase)
            .Build();

        Order order = OrderService.CreateOrder(computer);

        Assert.True(order.IsPowerRecommendationFollowed);
        Assert.True(order.HasNotRecommendedComponentsCombinations);
        Assert.True(order.DisclaimerOfWarranty);
    }

    [Fact]
    public void AssemblyWithoutFollowingPowerRecommendation()
    {
        Cpu cpu = new CpuEngineer(new CpuBuilder()).ManufactureIntelCoreI58400();
        Gpu gpu = new GpuEngineer(new GpuBuilder()).ManufactureGeForceRTX2060();
        Ram ram = new RamEngineer(new RamBuilder()).ManufactureKingstonFury();

        Motherboard motherboard = new MotherboardEngineer(
            new MotherboardBuilder()).ManufactureASRockH310CMDVS();

        CpuCoolingSystem coolingSystem = new CpuCoolingSystemEngineer(
            new CpuCoolingSystemBuilder()).ManufactureDeepCoolAK620();

        ComputerCase computerCase = new ComputerCaseEngineer(
            new ComputerCaseBuilder()).ManufactureStandardCase();

        PowerSupply powerSupply = new PowerSupplyEngineer(
            new PowerSupplyBuilder()).ManufactureExeGateTY600();

        SsdDrive ssd = new SsdDriveEngineer(
            new SsdDriveBuilder()).ManufactureApacerAS350Panther();

        HardDisk hardDisk = new HardDiskEngineer(
            new HardDiskBuilder()).ManufactureSeagateBarraCuda();

        ComputerComponentsService.Repository.AddMotherboard(motherboard);
        ComputerComponentsService.Repository.AddCpu(cpu);
        ComputerComponentsService.Repository.AddCoolingSystem(coolingSystem);
        ComputerComponentsService.Repository.AddPowerSupply(powerSupply);
        ComputerComponentsService.Repository.AddGpu(gpu);
        ComputerComponentsService.Repository.AddRam(ram);
        ComputerComponentsService.Repository.AddHardDisk(hardDisk);
        ComputerComponentsService.Repository.AddSsdDrive(ssd);
        ComputerComponentsService.Repository.AddComputerCase(computerCase);

        Computer computer = new ComputerConstructor()
            .AddMotherboard(motherboard)
            .AddCpu(cpu)
            .AddCoolingSystem(coolingSystem)
            .AddPowerSupply(powerSupply)
            .AddGpu(gpu)
            .AddRam(ram)
            .AddHardDisk(hardDisk)
            .AddSsdDrive(ssd)
            .AddCase(computerCase)
            .Build();

        Order order = OrderService.CreateOrder(computer);

        Assert.False(order.IsPowerRecommendationFollowed);
        Assert.False(order.HasNotRecommendedComponentsCombinations);
        Assert.False(order.DisclaimerOfWarranty);
    }

    [Fact]
    public void IncorrectAssemblyWithMissingCpu()
    {
        Gpu gpu = new GpuEngineer(new GpuBuilder()).ManufactureGeForceRTX2060();
        Ram ram = new RamEngineer(new RamBuilder()).ManufactureKingstonFury();

        Motherboard motherboard = new MotherboardEngineer(
            new MotherboardBuilder()).ManufactureASRockH310CMDVS();

        CpuCoolingSystem coolingSystem = new CpuCoolingSystemEngineer(
            new CpuCoolingSystemBuilder()).ManufactureDeepCoolAK620();

        ComputerCase computerCase = new ComputerCaseEngineer(
            new ComputerCaseBuilder()).ManufactureStandardCase();

        PowerSupply powerSupply = new PowerSupplyEngineer(
            new PowerSupplyBuilder()).ManufactureCougarBXM1200();

        SsdDrive ssd = new SsdDriveEngineer(
            new SsdDriveBuilder()).ManufactureApacerAS350Panther();

        ComputerComponentsService.Repository.AddMotherboard(motherboard);
        ComputerComponentsService.Repository.AddCoolingSystem(coolingSystem);
        ComputerComponentsService.Repository.AddPowerSupply(powerSupply);
        ComputerComponentsService.Repository.AddGpu(gpu);
        ComputerComponentsService.Repository.AddRam(ram);
        ComputerComponentsService.Repository.AddSsdDrive(ssd);
        ComputerComponentsService.Repository.AddComputerCase(computerCase);

        _ = Assert.Throws<MissingComponentException>(() =>
        {
            _ = new ComputerConstructor()
                .AddMotherboard(motherboard)
                .AddCoolingSystem(coolingSystem)
                .AddPowerSupply(powerSupply)
                .AddGpu(gpu)
                .AddRam(ram)
                .AddSsdDrive(ssd)
                .AddCase(computerCase)
                .Build();
        });
    }

    [Fact]
    public void IncorrectAssemblyFromIncompatibleCpu()
    {
        Cpu cpu = new CpuEngineer(new CpuBuilder()).ManufactureIntelPentiumG4400();
        Gpu gpu = new GpuEngineer(new GpuBuilder()).ManufactureGeForceRTX2060();
        Ram ram = new RamEngineer(new RamBuilder()).ManufactureKingstonFury();

        Motherboard motherboard = new MotherboardEngineer(
            new MotherboardBuilder()).ManufactureASRockH310CMDVS();

        CpuCoolingSystem coolingSystem = new CpuCoolingSystemEngineer(
            new CpuCoolingSystemBuilder()).ManufactureDeepCoolAK620();

        ComputerCase computerCase = new ComputerCaseEngineer(
            new ComputerCaseBuilder()).ManufactureStandardCase();

        PowerSupply powerSupply = new PowerSupplyEngineer(
            new PowerSupplyBuilder()).ManufactureCougarBXM1200();

        SsdDrive ssd = new SsdDriveEngineer(
            new SsdDriveBuilder()).ManufactureApacerAS350Panther();

        ComputerComponentsService.Repository.AddCpu(cpu);
        ComputerComponentsService.Repository.AddMotherboard(motherboard);
        ComputerComponentsService.Repository.AddCoolingSystem(coolingSystem);
        ComputerComponentsService.Repository.AddPowerSupply(powerSupply);
        ComputerComponentsService.Repository.AddGpu(gpu);
        ComputerComponentsService.Repository.AddRam(ram);
        ComputerComponentsService.Repository.AddSsdDrive(ssd);
        ComputerComponentsService.Repository.AddComputerCase(computerCase);

        _ = Assert.Throws<IncompatibleComponentException>(() =>
        {
            _ = new ComputerConstructor()
                .AddCpu(cpu)
                .AddMotherboard(motherboard)
                .AddCoolingSystem(coolingSystem)
                .AddPowerSupply(powerSupply)
                .AddGpu(gpu)
                .AddRam(ram)
                .AddSsdDrive(ssd)
                .AddCase(computerCase)
                .Build();
        });

        _ = Assert.Throws<IncompatibleComponentException>(() =>
        {
            _ = new ComputerConstructor()
                .AddMotherboard(motherboard)
                .AddCpu(cpu)
                .Build();
        });
    }

    [Fact]
    public void IncorrectAssemblyFromIncompatibleCoolingSystem()
    {
        Cpu cpu = new CpuEngineer(new CpuBuilder()).ManufactureIntelPentiumG4400();

        CpuCoolingSystem coolingSystem = new CpuCoolingSystemBuilder()
            .AddDimensions(new Dimensions(50, 50, 50))
            .AddMaxDissipatedHeatMass(100)
            .AddSupportedSocket(CpuSocket.LGA2066)
            .Build();

        ComputerComponentsService.Repository.AddCpu(cpu);
        ComputerComponentsService.Repository.AddCoolingSystem(coolingSystem);

        _ = Assert.Throws<IncompatibleComponentException>(() =>
        {
            _ = new ComputerConstructor()
                .AddCpu(cpu)
                .AddCoolingSystem(coolingSystem)
                .Build();
        });
    }

    [Fact]
    public void IncorrectAssemblyFromIncompatibleRam()
    {
        Cpu cpu = new CpuEngineer(new CpuBuilder()).ManufactureIntelPentiumG4400();
        Ram ram = new RamEngineer(new RamBuilder()).ManufactureKingstonFury();

        Motherboard motherboard = new MotherboardEngineer(
            new MotherboardBuilder()).ManufactureAFOXIH110D4MA2();

        ComputerComponentsService.Repository.AddCpu(cpu);
        ComputerComponentsService.Repository.AddMotherboard(motherboard);
        ComputerComponentsService.Repository.AddRam(ram);

        _ = Assert.Throws<IncompatibleComponentException>(() =>
        {
            _ = new ComputerConstructor()
                .AddMotherboard(motherboard)
                .AddRam(ram)
                .Build();
        });

        _ = Assert.Throws<IncompatibleComponentException>(() =>
        {
            _ = new ComputerConstructor()
                .AddCpu(cpu)
                .AddRam(ram)
                .Build();
        });
    }

    [Fact]
    public void IncorrectAssemblyFromIncompatibleComputerCase()
    {
        Gpu gpu = new GpuEngineer(new GpuBuilder()).ManufactureGeForceRTX2060();
        Gpu bigGpu = new GpuBuilder().BaseOn(gpu).AddWidth(130).Build();

        Motherboard motherboard = new MotherboardEngineer(
            new MotherboardBuilder()).ManufactureAFOXIH110D4MA2();

        Motherboard bigMotherboard = new MotherboardBuilder()
            .BaseOn(motherboard)
            .AddFormFactor(MotherboardFormFactor.WTX)
            .Build();

        CpuCoolingSystem coolingSystem = new CpuCoolingSystemEngineer(
            new CpuCoolingSystemBuilder()).ManufactureDeepCoolAK620();

        ComputerCase bigCase = new ComputerCaseEngineer(
            new ComputerCaseBuilder()).ManufactureBigCase();

        ComputerCase smallCase = new ComputerCaseEngineer(
            new ComputerCaseBuilder()).ManufactureSmallCase();

        ComputerComponentsService.Repository.AddGpu(bigGpu);
        ComputerComponentsService.Repository.AddMotherboard(motherboard);
        ComputerComponentsService.Repository.AddMotherboard(bigMotherboard);
        ComputerComponentsService.Repository.AddCoolingSystem(coolingSystem);
        ComputerComponentsService.Repository.AddComputerCase(bigCase);
        ComputerComponentsService.Repository.AddComputerCase(smallCase);

        _ = Assert.Throws<IncompatibleComponentException>(() =>
        {
            _ = new ComputerConstructor()
                .AddMotherboard(motherboard)
                .AddCase(bigCase)
                .Build();
        });

        _ = Assert.Throws<IncompatibleComponentException>(() =>
        {
            _ = new ComputerConstructor()
                .AddGpu(bigGpu)
                .AddCase(bigCase)
                .Build();
        });

        _ = Assert.Throws<IncompatibleComponentException>(() =>
        {
            _ = new ComputerConstructor()
                .AddMotherboard(bigMotherboard)
                .AddCoolingSystem(coolingSystem)
                .AddCase(smallCase)
                .Build();
        });
    }

    [Fact]
    public void IncorrectAssemblyFromIncompatiblePowerSupply()
    {
        Gpu gpu = new GpuEngineer(new GpuBuilder()).ManufactureGeForceRTX2060();

        PowerSupply powerSupply = new PowerSupplyEngineer(
            new PowerSupplyBuilder()).ManufactureExeGateUN350();

        ComputerComponentsService.Repository.AddGpu(gpu);
        ComputerComponentsService.Repository.AddPowerSupply(powerSupply);

        _ = Assert.Throws<IncompatibleComponentException>(() =>
        {
            _ = new ComputerConstructor()
                .AddGpu(gpu)
                .AddPowerSupply(powerSupply)
                .Build();
        });
    }

    [Fact]
    public void IncorrectAssemblyFromIncompatibleWiFiAdapter()
    {
        Motherboard motherboard = new MotherboardEngineer(
           new MotherboardBuilder()).ManufactureASRockH310CMDVS();

        WiFiAdapter wifiAdapter = new WiFiAdapterEngineer(
           new WiFiAdapterBuilder()).ManufactureTPLinkArcherT2E();

        ComputerComponentsService.Repository.AddMotherboard(motherboard);
        ComputerComponentsService.Repository.AddWiFiAdapter(wifiAdapter);

        _ = Assert.Throws<IncompatibleComponentException>(() =>
        {
            _ = new ComputerConstructor()
                .AddMotherboard(motherboard)
                .AddWiFiAdapter(wifiAdapter)
            .Build();
        });
    }

    [Fact]
    public void IncorrectAssemblyFromMotherboardWithInsufficientNumberOfSataSlots()
    {
        Motherboard motherboard = new MotherboardEngineer(
           new MotherboardBuilder()).ManufactureASRockH310CMDVS();

        var ssdEngineer = new SsdDriveEngineer(new SsdDriveBuilder());
        SsdDrive ssd1 = ssdEngineer.ManufactureApacerAS350Panther();
        SsdDrive ssd2 = ssdEngineer.ManufactureApacerAS350Panther();
        SsdDrive ssd3 = ssdEngineer.ManufactureApacerAS350Panther();
        SsdDrive ssd4 = ssdEngineer.ManufactureApacerAS350Panther();
        SsdDrive ssd5 = ssdEngineer.ManufactureApacerAS350Panther();

        ComputerComponentsService.Repository.AddMotherboard(motherboard);
        ComputerComponentsService.Repository.AddSsdDrive(ssd1);
        ComputerComponentsService.Repository.AddSsdDrive(ssd2);
        ComputerComponentsService.Repository.AddSsdDrive(ssd3);
        ComputerComponentsService.Repository.AddSsdDrive(ssd4);
        ComputerComponentsService.Repository.AddSsdDrive(ssd5);

        _ = Assert.Throws<IncompatibleComponentException>(() =>
        {
            _ = new ComputerConstructor()
                .AddMotherboard(motherboard)
                .AddSsdDrive(ssd1)
                .AddSsdDrive(ssd2)
                .AddSsdDrive(ssd3)
                .AddSsdDrive(ssd4)
                .AddSsdDrive(ssd5)
                .Build();
        });
    }

    [Fact]
    public void AssemblyFromUnregisteredComponent()
    {
        Cpu cpu = new CpuEngineer(new CpuBuilder()).ManufactureIntelPentiumG4400();
        Gpu gpu = new GpuEngineer(new GpuBuilder()).ManufactureGeForceRTX2060();
        Ram ram = new RamEngineer(new RamBuilder()).ManufactureKingstonFury();

        Motherboard motherboard = new MotherboardEngineer(
            new MotherboardBuilder()).ManufactureASRockH310CMDVS();

        CpuCoolingSystem coolingSystem = new CpuCoolingSystemEngineer(
            new CpuCoolingSystemBuilder()).ManufactureDeepCoolAK620();

        ComputerCase computerCase = new ComputerCaseEngineer(
            new ComputerCaseBuilder()).ManufactureStandardCase();

        PowerSupply powerSupply = new PowerSupplyEngineer(
            new PowerSupplyBuilder()).ManufactureCougarBXM1200();

        SsdDrive ssd = new SsdDriveEngineer(
            new SsdDriveBuilder()).ManufactureApacerAS350Panther();

        HardDisk hardDisk = new HardDiskEngineer(
            new HardDiskBuilder()).ManufactureSeagateBarraCuda();

        WiFiAdapter wifiAdapter = new WiFiAdapterEngineer(
            new WiFiAdapterBuilder()).ManufactureTPLinkArcherT2E();

        _ = Assert.Throws<ComponentNotRegisteredException>(() =>
        {
            _ = new ComputerConstructor().AddCpu(cpu);
        });

        _ = Assert.Throws<ComponentNotRegisteredException>(() =>
        {
            _ = new ComputerConstructor().AddGpu(gpu);
        });

        _ = Assert.Throws<ComponentNotRegisteredException>(() =>
        {
            _ = new ComputerConstructor().AddRam(ram);
        });

        _ = Assert.Throws<ComponentNotRegisteredException>(() =>
        {
            _ = new ComputerConstructor().AddMotherboard(motherboard);
        });

        _ = Assert.Throws<ComponentNotRegisteredException>(() =>
        {
            _ = new ComputerConstructor().AddCoolingSystem(coolingSystem);
        });

        _ = Assert.Throws<ComponentNotRegisteredException>(() =>
        {
            _ = new ComputerConstructor().AddCase(computerCase);
        });

        _ = Assert.Throws<ComponentNotRegisteredException>(() =>
        {
            _ = new ComputerConstructor().AddPowerSupply(powerSupply);
        });

        _ = Assert.Throws<ComponentNotRegisteredException>(() =>
        {
            _ = new ComputerConstructor().AddSsdDrive(ssd);
        });

        _ = Assert.Throws<ComponentNotRegisteredException>(() =>
        {
            _ = new ComputerConstructor().AddHardDisk(hardDisk);
        });

        _ = Assert.Throws<ComponentNotRegisteredException>(() =>
        {
            _ = new ComputerConstructor().AddWiFiAdapter(wifiAdapter);
        });
    }
}
