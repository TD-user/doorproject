﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntitiesDB
{
    public class Block
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Vrizka { get; set; }
        public string AddOns { get; set; }
        public int DoorOneID { get; set; }
        public Door DoorOne { get; set; }
        public int? DoorTwoID { get; set; }
        public Door DoorTwo { get; set; }
        public int BoxID { get; set; }
        public DoorBox Box { get; set; }
        public int HingeOneID { get; set; }
        public Hinge HingeOne { get; set; }
        public int? HingeTwoID { get; set; }
        public Hinge HingeTwo { get; set; }
        public byte CountHinges { get; set; }
        public int LockID { get; set; }
        public Lock Lock { get; set; }
        public string InsertPotai { get; set; }
        public int DoorstepID { get; set; }
        public DoorStep Doorstep { get; set; }
        public string Note { get; set; }
        public string OrderNumber { get; set; }
        [ForeignKey("TechCard")]
        public int TechCardID { get; set; }
        public TechnologicalCard TechCard { get; set; }
        public byte Status { get; set; }
    }
}
