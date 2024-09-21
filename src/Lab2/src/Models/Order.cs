using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Order
{
    public Order(
        Computer computer,
        bool hasNotRecommendedComponentsCombinations,
        bool isPowerRecommendationFollowed)
    {
        Computer = computer ?? throw new ArgumentNullException(nameof(computer));
        HasNotRecommendedComponentsCombinations = hasNotRecommendedComponentsCombinations;
        IsPowerRecommendationFollowed = isPowerRecommendationFollowed;
    }

    public Computer Computer { get; }
    public bool HasNotRecommendedComponentsCombinations { get; }
    public bool IsPowerRecommendationFollowed { get; }

    public bool DisclaimerOfWarranty => HasNotRecommendedComponentsCombinations;
}
