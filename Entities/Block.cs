using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Block
    {
        public string BlockId { get; set; } //номер блоку
        public string CuttingType { get; set; } //врізки
        public string AdditionalInfo { get; set; } //ДОП
        public string Door1 { get; set; } //Найменування полотна
        public string Door2 { get; set; } //найменування полотна 2
        public string DoorBox { get; set; } //коробка
        public string Hinge1 { get; set; } //завіси
        public string Hinge2 { get; set; } //завіси № 2
        public string HingeCount { get; set; } //кількість завіс
        public string LockType { get; set; } //замок
        public string InsertingSecret { get; set; } //врізка потаю відповідної планки
        public string DoorStep { get; set; } //поріг
        public string Note { get; set; } //примітка
        public string OrderNumber { get; set; } //номер замовлення
        public Status Status { get; set; } = Status.Preparation;

    }
}
