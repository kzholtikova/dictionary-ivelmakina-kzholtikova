# assignment-three-template
## Хеші, списки та словники

### Мета роботи:
Розібратись із двома важливими структурами даних: зв'язним списком та словником (він же асоціативний масив), згадати та використати на практиці поняття хеш-функції (українською також пишеться як "геш")

## Завдання
Починаючи з першого терму, ви вже звикли використовувати структуру даних "словник" у пайтоні та С# - вона дозволяє зберігати пари ключ-значення, надаючи швидкий доступ за ключем до відповідного значення, при цьому зберігаючи константний час виконання для будь-якої кількості даних. В цій роботі ми реалізуємо цю структуру даних, а точніше один з видів словників - так звану хеш-таблицю (hashtable).

###### Теорія
Хеш-таблиці мають величезне значення та дуже широке використання, наприклад:
- Алгоритм Рабіна-Карпа пошуку рядків, що використовується для пошуку плагіату в текстах;
- Зберігання відповідності імені файлу та його шляху на диску у файлових системах;
- Зберігання закешованої інформації для надання швидких відповідей замість повторного обрахунку (наприклад, кеш веб-сторінок);
- Індексація полів у базах даних для швидкого пошуку;
- Представлення об'єктів у таких мовах як JS, Python, Lua чи Ruby;

Перш ніж почати виконувати завдання, прочитайте 5 розділ Grokking Algorithms (книга є на муддлі) - там детально та зрозумілою мовою описано поняття хеш-функції, приклади використання хеш-таблиць, поняття коефіцієнту заповнення та інші важливі поняття. Інші джерела:
- На ютубі є багато великих лекцій або коротких ілюстрованих пояснень. Рекомендую подивитись, наприклад пояснення з [гарвардського курсу CS50](https://www.youtube.com/watch?v=btT4bCOvqjs) або [таке](https://www.youtube.com/watch?v=shs0KM3wKv8);
- Гарна візуалізація роботи хеш-таблиці є [тут](https://www.cs.usfca.edu/~galles/visualization/OpenHash.html) (клацати insert/delete/find)
- Достатньо детальна стаття про хеш-таблиці є [на вікіпедії](https://en.wikipedia.org/wiki/Hash_table);
- Хеш-таблицям також присвячений розділ 11 підручника Кормена;


###### Зв'язний список
Для реалізації хеш-таблиці нам буде потрібно реалізувати ще одну допоміжну структуру даних - зв'язний список:
- Прочитайте розділ 10.2 підручника Кормена, в ньому достатньо детально, з псевдокодом основних функцій описана ідея та вигляд зв'язних списків;
- Ще можна подивтись [відео про зв'язні списки](https://www.youtube.com/watch?v=njTh_OwMljA);
- [Багато прикладів та матеріалів](https://www.geeksforgeeks.org/data-structures/linked-list/);
- Інтерактивно на роботу зв'язного списку можна подивитись [тут](https://antoniosarosi.github.io/Linked-List-Visualization/) або [тут](https://kalkicode.com/data-structure/single-linked-list-visualization)
- Скієна розділ 3.1.2


Для реалізації зв'язного списку, почнемо з наступного коду (всі приклади теоретично можна скопіювати у вашу роботу, але краще з точку зору практики буде якщо ви на них подивитесь та наберете самостійно):

```C#
    public class KeyValuePair
    {
        public string Key { get; }

        public string Value { get; }

        public KeyValuePair(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
```

Це невеликий допоміжний клас, що містить в собі пару ключ та значення (обидва мають тип `string`). Тепер на основі цього класу ми можемо почати робти зв'язний список. Почнемо з класу, що буде основною цеглинкою зв'язного списку - елементом, що містить в собі значення та посилання на наступний елемент:

```C#
    public class LinkedListNode
    {
        public KeyValuePair Pair { get; }
        
        public LinkedListNode Next { get; set; }

        public LinkedListNode(KeyValuePair pair, LinkedListNode next = null)
        {
            Pair = pair;
            Next = next;
        }
    }
```

У цьому класі `Next` має як геттер, так і сеттер (`get` та `set`), що допоможе при необхідності змінювати вказівник на наступний елемент. Тепер можна переходити до самого зв'язного списку:

```C#
    public class LinkedList
    {
        private LinkedListNode _first;

        public void Add(KeyValuePair pair)
        {
            // add provided pair to the end of the linked list
        }

        public void RemoveByKey(string key)
        {
            // remove pair with provided key
        }

        public KeyValuePair GetItemWithKey(string key)
        {
            // get pair with provided key, return null if not found
        }
    }
```

Реалізуйте всі наведені методи у класі, пам'ятаючи, що додавання завжди додає новий елемент останнім у список, а видалення - знаходить потрібний елемент та переміщує вказівник з попереднього на наступний, виключаючи таким чином більше непотрібний елемент з ланцюжку. За бажання, можете модифікувати цей клас, так щоб зберігалося посилання і на останній елемент.

###### Нарешті, словник
Маючи зв'язний список ми можемо реалізувати вже і основну структуру - словник. Пам'ятайте, що додавання у словник відбувається за наступним алгоритмом:
1. Отримати ключ та значення для додавання
2. Знайти хеш від ключу
3. Знайти відповідну корзину (bucket) для додавання - для цього достатньо просто знайти залишок від ділення хешу на кількість бакетів
4. Якщо в цій корзині вже є зв'язний список - додати новий елемент в кінець, якщо ще ні - створити список та додати

Доступ до елемента за ключем:
1. Отримати ключ
2. Знайти хеш від ключу
3. Знайти відповідну корзину (bucket) для додавання
4. Якщо в цій корзині вже є зв'язний список - спробувати дістати зі списку елемент з таким ключем, якщо ще ні - повернути `null`

Почніть з наступного коду:
```C#
    public class StringsDictionary
    {
        private const int InitialSize = 10;

        private LinkedList[] _buckets = new LinkedList[InitialSize];
        
        public void Add(string key, string value)
        {
            
        }

        public void Remove(string key)
        {
            
        }

        public string Get(string key)
        {
            
        }


        private int CalculateHash(string key)
        {
            // function to convert string value to number 
        }
    }
```

Спробуйте написати влашну хеш-функцію у методі `CalculateHash(string key)` - отримуючи на вході рядок, ви можете зробити будь-які маніпуляції над символами цього рядку (наприклад, перемножити їх - це зробити легко, адже `char` завжди можна привести до `byte` або `int`).

В базовому варіанті завдання, розширення хеш-таблиці реалізовувати непотрібно

###### І тепер - використання

Напишіть програму, що читає з диску наданий словник, складає всі слова з тлумаченням у написану вами хеш-таблицю, та у інтерактивному режимі просить користувача вводити слово за словом та виводить його тлумачення. Для того щоб прочитати всі рядки з файлу з диску, можете скористатися зручною функцією `File.ReadAllLines(pathToFile)`

## Додаткове завдання
(+2 бали) Додайте у хештаблицю підрахунок лоад-фактора (відношення кількості не порожніх бакетів до їх загальної кількості) та реалізуйте автоматичне розширення хештаблиці при досягненні певного значення лоад-фактору. При розширенні, кількість бакетів збільшується та усі наявні елементи хеш-таблиці повторно розподіляються по бакетах

## Контрольні питання
- Що таке хеш-функція? Приведіть приклади гарних та поганих хеш-функцій.
- Як працює зв'язний список та в яких ситуаціях він ефективний? В чому його переваги?
- Яка складність операцій в хеш-таблицях в середньому та найгіршому випадках?
- Що таке колізія у хеш-таблиці і як вона вирішується?
- За рахунок чого в хеш-таблиці досягається константна складність додавання елементів?

## Оцінювання
Максимальний бал - 8 (+2 можливих додаткових бали):
- реалізація хеш-таблиці та зв'язного списку - _4 бал_;
- відповіді на теоретичні питання - _2 бали_;
- виконання додаткового практичного завдання при здачі - _2 бали_;
- реалізація зібльшення хеш-таблиці - _+2 бали_


