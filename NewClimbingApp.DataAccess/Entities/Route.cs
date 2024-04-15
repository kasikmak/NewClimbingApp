using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.DataAccess.Entities;

public class Route : EntityBase
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [MaxLength(5)]
    public string Grade { get; set; }

    public float GradeAsFloat
    {
        get
        {
            switch (this.Grade.ToLower())
            {
                case "4a" or "IV-":
                    return 4f;
                case "4b" or "IV":
                    return 4.1f;
                case "4c" or "IV+":
                    return 4.2f;
                case "5a" or "V-":
                    return 5f;
                case "5b" or "V":
                    return 5.1f;
                case "5c" or "V+":
                    return 5.2f;
                case "5c+" or "VI-":
                    return 6f;
                case "6a" or "VI":
                    return 6.1f;
                case "6a+" or "VI+":
                    return 6.2f;
                case "6b" or "VI.1":
                    return 6.3f;
                case "6b+" or "VI.1+":
                    return 6.4f;
                case "6c" or "VI.2":
                    return 6.5f;
                case "6c+" or "VI.2+":
                    return 6.6f;
                case "7a" or "VI.3":
                    return 7f;
                case "7a+" or "VI.3+":
                    return 7.1f;
                case "7b" or "VI.4":
                    return 7.2f;
                case "7c" or "VI.4+":
                    return 7.3f;
                case "7c+" or "VI.5":
                    return 7.4f;
                case "8a" or "VI.5+":
                    return 8f;
                case "8b" or "VI.6":
                    return 8.1f;
                case "8b+" or "VI.6+":
                    return 8.2f;
                case "8c" or "VI.7":
                    return 8.3f;
                case "8c+" or "VI.7+":
                    return 8.4f;
                case "9a" or "VI.8":
                    return 9f;
                case "9a+" or "9b" or "VI.8+":
                    return 9.1f;
                case "9b+" or "VI.9":
                    return 9.2f;
                case "9c" or "VI.9+":
                    return 9.3f;
                default:
                    return 0f;
            }
        }
    }
    public int? Length { get; set; }

    public bool IsClimbed { get; set; }

    public enum RouteType
    {
        Sport = 0,
        Boulder = 1
    };

    public RouteType Type { get; set; }
    public List<User>? Climbers { get; set; }

    public int? EquiperId { get; set; }

    public int? CragId { get; set; }

    public int? AscentId { get; set; }

    public Ascent? Ascent { get; set; }
}

