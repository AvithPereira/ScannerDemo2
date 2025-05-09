using System;

namespace ScannerDemo2.Models
{
    public class FlyoutMenuItem
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public Type TargetPage { get; set; }
    }
}
