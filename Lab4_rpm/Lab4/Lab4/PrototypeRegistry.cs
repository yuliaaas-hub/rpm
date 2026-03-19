using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public sealed class PrototypeRegistry
    {
        // === ПОТОКОБЕЗОПАСНЫЙ SINGLETON ЧЕРЕЗ Lazy<T> ===
        private static readonly Lazy<PrototypeRegistry> _instance =
            new Lazy<PrototypeRegistry>(() => new PrototypeRegistry());

        public static PrototypeRegistry Instance => _instance.Value;

        private readonly Dictionary<string, Computer> _prototypes;

        // Приватный конструктор — нельзя создать экземпляр извне
        private PrototypeRegistry()
        {
            _prototypes = new Dictionary<string, Computer>();
            RegisterDefaultPrototypes();
        }

        private void RegisterDefaultPrototypes()
        {
            // Регистрация прототипов через фабрики
            _prototypes["office"] = new OfficeComputerFactory().Construct();
            _prototypes["gaming"] = new GamingComputerFactory().Construct();
            _prototypes["home"] = new HomeComputerFactory().Construct();
        }

        // Возвращает ГЛУБОКУЮ копию прототипа, чтобы клиент не изменил оригинал
        public Computer GetPrototype(string key)
        {
            if (!_prototypes.TryGetValue(key, out var prototype))
            {
                throw new KeyNotFoundException($"Prototype '{key}' not found in registry");
            }
            return prototype.DeepCopy(); // Возвращаем копию, а не ссылку!
        }

        // Метод для добавления нового прототипа (по желанию)
        public void RegisterPrototype(string key, Computer prototype)
        {
            _prototypes[key] = prototype.DeepCopy();
        }

        // Проверка, что это действительно один экземпляр (для демонстрации)
        public bool IsSameInstance(PrototypeRegistry other)
        {
            return ReferenceEquals(this, other);
        }
    }
}
