namespace SulpakTask;

public class FistTask
{
    /*await Parallel.ForEachAsync((await _onecPriceRepository.GetPriceTypes())
    new ParallelOptions() { MaxDegreeOfParallelism = maxDegreeOfParallelism }
    , (priceType, ct) => ProcessPriceType(priceType, ct));*/
    
    
    /*
     * идёт асинхронный цикл по и переберает список цен. каждый итирацию и вызывает функцию _onecPriceRepository.GetPriceTypes() и (priceType, ct) => ProcessPriceType(priceType, ct)
     *
     * new ParallelOptions() { MaxDegreeOfParallelism = maxDegreeOfParallelism }
     * Создаёт новый экземпляр ParallelOptions в MaxDegreeOfParallelism присваеваеться maxDegreeOfParallelism
     *
     * (priceType, ct) => ProcessPriceType(priceType, ct)
     * Это лямда  Каждый элемент коллекции будет передан в метод ProcessPriceType
     */
    
    
    /*private async ValueTask ProcessPriceType(PriceType_1cDTO priceType, CancellationToken ct)
    {        
        List<Price_1cDTO> prs = (await _onecPriceRepository.GetFullPriceForPriceType(priceType.PriceTypeId))
            .ToList();        
        await Task.WhenAll(new[]
        {
            _priceRepository.IU_CatalogPrices(prs.Adapt<List<Price_Dto>>()),
            PreProcessDivisionPrice(priceType.PriceTypeId, prs, ct)
        });
        
        этот метод(асинхронный) принемает два параметра CancellationToken и PriceType_1cDTO
        используемый для отмены покупки выполнения операции
         await Task.WhenAll(new[]
        {
            _priceRepository.IU_CatalogPrices(prs.Adapt<List<Price_Dto>>()), происходит проверка листа самого запроса
            PreProcessDivisionPrice(priceType.PriceTypeId, prs, ct)
            происходит предварительная обработки цены. принемает цену, токен отмены, PriceTypeId (индификатор типа ценны) 
        });
        происходит проверка листа 
        искользуеться два метода парарельно используеться 
         
    }*/


    /*
         * await Parallel.ForEachAsync(priorityPriceType.Divisions, new ParallelOptions()
         * { MaxDegreeOfParallelism = maxDegreeOfParallelism }, async (div, ct) => { DATA});
         */
        //асинхронный цикл который использует асинхронную параллельную обработку элементов коллекции priorityPriceType.Divisions
        
        /*
         * c 63 по 69 строчник кода(в теле цикла)
         * создается новая пара ключ-значение (KeyValuePair). Ключ представлен объектом DivisionPriceStruct, который содержит информацию о типе цены
         */
        
        /*public record PriceTypePriority_1cDTO
    {
        public Guid PriceTypeId { get; set; }  идентификатор типа цены
        public string PriceTypeCode { get; set; } код типа цены
        public int Priority { get; set; } приоритет типа цены
        public Guid CurrencyId { get; set; } идентификатор валюты
        public Guid DivisionListId { get; set; } идентификатор списка отделений 
        public List<Division_1cDTO> Divisions { get; set; }  список отделений
    }
    public readonly record struct DivisionPriceStruct : IEquatable<DivisionPriceStruct>
    {
        public DivisionPriceStruct(Guid priceTypeGuid, Guid goodGuid, string shopCode)
        {
            PriceTypeGuid = priceTypeGuid;
            GoodGuid = goodGuid;
            ShopCode = shopCode;
           Конструктор 
        }
        
        public Guid GoodGuid { get; }
        public Guid PriceTypeGuid { get; }
        public string ShopCode { get; }
        
        public override int GetHashCode() =>
            HashCode.Combine(GoodGuid.GetHashCode(), PriceTypeGuid.GetHashCode(), ShopCode.GetHashCode());
        создание хеш кода
        public bool Equals(DivisionPriceStruct? other) => other.GetHashCode() == GetHashCode();
        Метод Equals(DivisionPriceStruct? other) реализован для сравнения хэш-кодов двух экземпляров DivisionPriceStruct на равенство.
    }*/
        
        /*DivisionPriceStruct Это не изменяемая структура данных readonly record struct
         * которая реализует итерфейс
         * 
         */ 
        /*резюмируем
            Цель данного кода заключается в обработке ценовых типов
            await Parallel.ForEachAsync((await _onecPriceRepository.GetPriceTypes())
            new ParallelOptions() { MaxDegreeOfParallelism = maxDegreeOfParallelism }
        , (priceType, ct) => ProcessPriceType(priceType, ct));
         Для каждого ценового типа вызывается метод ProcessPriceType(priceType, ct), 
            который будет обрабатывать ценовой тип.
            
            Сам код крассвый довольно понятный и оптимизированый. По сути выдержит высокую 
            нагрузку запросов и будет быстро выполнятьсяы
        
        
             1) System.Threading.Tasks.Parallel 
             System.Collections
             2) версия .net 6 я не понял если честно какая версия я думаю свежая верся или .net 5
             
             3)_divisionPriceDictionary является экземпляром класса ConcurrentDictionary<DivisionPriceStruct
                потому что он использует AddOrUpdate
             
             _divisions_byPriceType_dic  является экземпляром класса Dictionary<Guid, PriceTypePriority_1cDTO> 
                он использует TryGetValue
                
            4). я бы убралб 2 метода GetHashCode() Equals и поместил бы другое место там будет по красивей и мб понятней
         */
        
    }
     
