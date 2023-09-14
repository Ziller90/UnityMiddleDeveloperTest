# UnityMiddleDeveloperTest
Выполнение тестового задания для CarX Technologies
В изначальном коде использовались public переменные. Они были заменены на поля с атрибутом [SerializedField] для сокрытия переменных от других классов, которые не должны о них знать.
Изменен нейминг переменных. Не считаю венгерскую нотацию в названии переменных оправданной в c#. Префиксы m_ довольно утомительно ставить, это удлиняет название переменных, что делает код менее удобным для чтения. Плюс, венгерская нотация на сколько я знаю мало распространена в среде Unity разработчиков. Это делает более сложной адаптацию к код стайлу новых разработчиков. Однако, если в CarX Technologies все таки применеяется венгерская нотация в названии переменных, я буду вовсе не против нее и смогу легко адаптироваться :)
Выношу код выстрела в отдельную функцию для удобства чтения кода
Смерть юнитов была перенесена в новый класс Health, так как существующий код нарушает логику и принцип единой отвественности. Снаряд не должен вызывать функцию смерти, а может только наносить урон противнику.
Для поиска противников на сцене использовался метод “FindObjectsOfType()”, который является очень тяжелым и может вызывать проблемы с производительностью. Для хранения списка юнитов на сцене был добавлен класс UnitsService. 
Для удобного доступа к классу UnitService был реализован паттер Service locator. Были добавлены скрипты “Service” и “ApplicationServices” 
Для регистрации юнитов в UnitsService был разработан класс Unit. Он регистрирует юнита при появлении на сцене и удаляет его из списка при срабатывании события dieEvent;
В изначальном коде UnitMover выполняет как функцию движения юнита, так и функцию отслеживания его приближения к цели. Это нарушает принцип единой ответственности. Поэтому было принято решение вынести функционал отслеживания приближения к цели и удаления юнита при приближении к цели в класс UnitAI. UnitMover стал служебным классом, выполняющим исключительно функцию перемещения юнита в определенную точку, задаваемую в методе SetMoveTarget(GameObject moveTarget)
Сделан перенос открывающей скобки на следующую строку во всех методах и классах для увеличения читабельности кода. Это также соответствует официальному код стайлу C#
Изменена архитектура снярядов. Добавлен ProjectileBase скрипт, а также отдельный скрит наносящий урон противникам при попадании.
Добавлен скрипт Range. Он позволяет задать абстрактный радиус, а также имеет функцию для проверки того, находится ли заданный объект в данном радиусе.
Добавлен компонент UnitDetector, хранящий очередь противников, которые вошли в радиус заданный компонентом Range, а также кидающий событие об изменении текущей цели для атаки.
Добавлена стрельба с упреждением для Cannon Tower.
Добавлен скрипт ProjectilesSpawner, позволяющий настраивать частоту спавна снарядов для различных типов башен.
