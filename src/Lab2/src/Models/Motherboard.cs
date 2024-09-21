using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Motherboard
{
    private readonly List<RamFormFactor> _availableRamFormFactors;
    private readonly List<PciEVersion> _availablePciELines;

    public Motherboard(
        CpuSocket socket,
        IEnumerable<PciEVersion> availablePciELines,
        int sataPortsCount,
        Chipset chipset,
        int supportedDdrStandard,
        IEnumerable<RamFormFactor> availableRamFormFactors,
        MotherboardFormFactor formFactor,
        Bios bios,
        bool hasEmbeddedWiFiModule)
    {
        _availableRamFormFactors = availableRamFormFactors?.ToList()
            ?? throw new ArgumentNullException(nameof(availableRamFormFactors));

        _availablePciELines = availablePciELines?.ToList()
            ?? throw new ArgumentNullException(nameof(availablePciELines));

        RamSlotsCount = _availableRamFormFactors.Count;
        PciELinesCount = _availablePciELines.Count;

        Socket = socket;
        SataPortsCount = sataPortsCount;
        Chipset = chipset ?? throw new ArgumentNullException(nameof(chipset));
        SupportedDdrStandard = supportedDdrStandard;
        FormFactor = formFactor;
        Bios = bios ?? throw new ArgumentNullException(nameof(bios));
        HasEmbeddedWiFiModule = hasEmbeddedWiFiModule;
    }

    public CpuSocket Socket { get; }
    public int PciELinesCount { get; }
    public int SataPortsCount { get; }
    public Chipset Chipset { get; }
    public int SupportedDdrStandard { get; }
    public int RamSlotsCount { get; }
    public MotherboardFormFactor FormFactor { get; }
    public Bios Bios { get; }
    public bool HasEmbeddedWiFiModule { get; }

    public IReadOnlyList<RamFormFactor> AvailableRamFormFactors => _availableRamFormFactors;
    public IReadOnlyList<PciEVersion> AvailablePciELines => _availablePciELines;

    public Dimensions Dimensions => FormFactor switch
    {
        MotherboardFormFactor.AT => new Dimensions(305, 1, 330),
        MotherboardFormFactor.LPX => new Dimensions(229, 1, 330),
        MotherboardFormFactor.ATX => new Dimensions(244, 1, 305),
        MotherboardFormFactor.MicroATX => new Dimensions(170, 1, 220),
        MotherboardFormFactor.NLX => new Dimensions(229, 1, 343),
        MotherboardFormFactor.WTX => new Dimensions(356, 1, 425),
        MotherboardFormFactor.FlexATX => new Dimensions(191, 1, 229),
        MotherboardFormFactor.MiniITX => new Dimensions(170, 1, 170),
        MotherboardFormFactor.MiniDTX => new Dimensions(170, 1, 190),
        MotherboardFormFactor.EATX => new Dimensions(260, 1, 305),

        _ => throw new NotSupportedException(),
    };
}
