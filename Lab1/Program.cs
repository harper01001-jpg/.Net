using System;
using System.Text;

namespace Lab1
{
    // Базовий клас
    class Organization
    {
        protected string name;

        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }

        public Organization() { }

        public Organization(string name)
        {
            this.name = name;
        }

        // Поліморфний метод (для пізнього зв'язування)
        public virtual void GetInfo()
        {
            Console.WriteLine("Базова організація: " + name);
        }

        // Метод для демонстрації раннього зв’язування (приховування)
        public void Info()
        {
            Console.WriteLine("Це інформація з БАЗОВОГО класу Organization");
        }

        // Перевизначений метод Equals
        public override bool Equals(object obj)
        {
            if (obj is Organization other)
                return name == other.name;

            return false;
        }

        public override int GetHashCode()
        {
            return name?.GetHashCode() ?? 0;
        }
    }

    // Страхова компанія
    class InsuranceCompany : Organization
    {
        public string AgentSurname { get; set; }
        public int PoliciesCount { get; set; }
        public decimal TotalSum { get; set; }

        public InsuranceCompany() { }

        public InsuranceCompany(string name, string agentSurname, int policiesCount, decimal totalSum)
            : base(name)
        {
            AgentSurname = agentSurname;
            PoliciesCount = policiesCount;
            TotalSum = totalSum;
        }

        // Перевизначений поліморфний метод
        public override void GetInfo()
        {
            Console.WriteLine($"Страхова компанія: {name} | Агент: {AgentSurname} | Полісів: {PoliciesCount} | Сума: {TotalSum} грн");
        }

        // Прихований метод (раннє зв'язування)
        public new void Info()
        {
            Console.WriteLine("Це інформація з ПОХІДНОГО класу InsuranceCompany");
        }

        public override bool Equals(object obj)
        {
            if (obj is InsuranceCompany other)
                return base.Equals(obj) &&
                       AgentSurname == other.AgentSurname &&
                       PoliciesCount == other.PoliciesCount &&
                       TotalSum == other.TotalSum;

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), AgentSurname, PoliciesCount, TotalSum);
        }
    }

    // Будівна компанія
    class ConstructionCompany : Organization
    {
        public string ForemanSurname { get; set; }
        public decimal TotalEstimate { get; set; }
        public double TotalArea { get; set; }

        public ConstructionCompany() { }

        public ConstructionCompany(string name, string foremanSurname, decimal totalEstimate, double totalArea)
            : base(name)
        {
            ForemanSurname = foremanSurname;
            TotalEstimate = totalEstimate;
            TotalArea = totalArea;
        }

        public override void GetInfo()
        {
            Console.WriteLine($"Будівна компанія: {name} | Прораб: {ForemanSurname} | Кошторис: {TotalEstimate} грн | Площа: {TotalArea} кв.м");
        }

        public new void Info()
        {
            Console.WriteLine("Це інформація з ПОХІДНОГО класу ConstructionCompany");
        }

        public override bool Equals(object obj)
        {
            if (obj is ConstructionCompany other)
                return base.Equals(obj) &&
                       ForemanSurname == other.ForemanSurname &&
                       TotalEstimate == other.TotalEstimate &&
                       TotalArea == other.TotalArea;

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), ForemanSurname, TotalEstimate, TotalArea);
        }
    }

    // Метробуд
    class MetroConstruction : Organization
    {
        public string RouteName { get; set; }
        public int PassengersCount { get; set; }
        public double DistanceKm { get; set; }

        public MetroConstruction() { }

        public MetroConstruction(string name, string routeName, int passengersCount, double distanceKm)
            : base(name)
        {
            RouteName = routeName;
            PassengersCount = passengersCount;
            DistanceKm = distanceKm;
        }

        public override void GetInfo()
        {
            Console.WriteLine($"Метробуд: {name} | Маршрут: {RouteName} | Пасажирів: {PassengersCount} | Відстань: {DistanceKm} км");
        }

        public new void Info()
        {
            Console.WriteLine("Це інформація з ПОХІДНОГО класу MetroConstruction");
        }

        public override bool Equals(object obj)
        {
            if (obj is MetroConstruction other)
                return base.Equals(obj) &&
                       RouteName == other.RouteName &&
                       PassengersCount == other.PassengersCount &&
                       DistanceKm == other.DistanceKm;

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), RouteName, PassengersCount, DistanceKm);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Для коректного відображення українських літер
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            // Масив базового класу
            Organization[] organizations =
            {
                new Organization("Невідома ТОВ"),
                new InsuranceCompany("Оранта", "Коваленко", 150, 500000m),
                new ConstructionCompany("КиївМіськБуд", "Шевченко", 25000000m, 15000.5),
                new MetroConstruction("Київський Метрополітен", "Сирецько-Печерська", 1200000, 23.9)
            };

            Console.WriteLine("=== Пізнє зв’язування (override) ===");
            foreach (Organization org in organizations)
            {
                // Викликається метод відповідного похідного класу (динамічний поліморфізм)
                org.GetInfo();
            }

            Console.WriteLine("\n=== Раннє зв’язування (new) ===");

            InsuranceCompany ins = new InsuranceCompany("ТАС", "Петренко", 100, 200000m);
            Organization orgRef = ins;

            Console.Write("Виклик через змінну базового типу: ");
            orgRef.Info(); // Викличе метод з Organization

            Console.Write("Виклик через змінну похідного типу: ");
            ins.Info();    // Викличе метод з InsuranceCompany

            Console.WriteLine("\n=== Перевірка Equals ===");

            InsuranceCompany ins1 = new InsuranceCompany("ПЗУ", "Іванов", 50, 10000m);
            InsuranceCompany ins2 = new InsuranceCompany("ПЗУ", "Іванов", 50, 10000m);
            ConstructionCompany const1 = new ConstructionCompany("ПЗУ", "Іванов", 50m, 10000);

            Console.WriteLine($"Порівнюємо дві однакові страхові {ins1.GetType().Name}: " + ins1.Equals(ins2));
            Console.WriteLine($"Порівнюємо страхову {ins1.GetType().Name} та будівну {const1.GetType().Name} з однаковими даними: " + ins1.Equals(const1));
        }
    }
}