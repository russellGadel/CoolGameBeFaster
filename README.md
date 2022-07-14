# CoolGameBeFaster
 <html>
    <head>
        <title align="center"> Readme</title>
        <meta http-equiv="content-type" content="text/html; charset=utf-8">
        <style>
            .layer{
                line-height: 120%;
            }

            .layer subLine {
                padding: 10%;
            } 
            
            .layer subSubLine{
                padding: 20%;
            }

            </style>
    </head>

    <body>
        <div class = "layer">
            <h1 align = "center"> Описание проекта</h1>

            ![Alt text](/ReadmeAssets/Images/gameImg.jpg?raw=true) <br>

            2D мобильный проект(Android). Игрок с помощью контроллера управляет Кругом. На него постоянно летят различные объекты наносящие урон(стрелы, круги, уголки). <br>
            Игрок перемещается по карте собирая очки, при этом уклоняясь от объектов наносящих урон, и обходя препятствия.
            При попадании объекта наносящего урон в Игрока, игра завершается, выходит окно, где предлагается продолжить игру за просмотр рекламы, или заново начать уровень.
            Максимальное количество очков заработанных игроком сохраняются , и отображаются игроку на различных этапах. <br>
            В нижнем левом углу есть кнопка ускорения игрока. Одно нажатие на кнопку – первое ускорение. Двойное нажатие на кнопку – двойное ускорение. <br>
            В правом верхнем углу кнопка паузы.<br>
            
            <h3 align = "left"> Детали:  </h3> 
            
            •	Игра  бесконечная.<br>
            •	Этапы прохождения игры привязаны к количеству очков, которые были проспаунены. Определенное количество проспауненных очков привязано к уровню сложности.<br>
            •	Каждый уровень сложности уровня конфигурируется.<br>
            •	С течением времени  изменяются параметры спаунящихся очков(количество очков появляющихся одномоментно, время жизни, промежуток между спаунами), <br>
            изменяются параметры объектов наносящих урон(количество объектов появляющихся одномоментно, промежуток между спаунами, тип префаба который будет спаунится).
            Префаб объекта наносящего урон настраивается – внешний вид, скорость перемещения и т.д.
            •	Управление в мобильном проекте – контроллер в нижнем правом углу, PC – WASD. <br>
            •	Настраивается количество попыток прохождения уровня за просмотр рекламы.<br>
            •	Места соединения с внешними ресурсами, проверки интернет соединения: <br>
           
            <subLine>- запрос RemoteConig data, </subLine> <br>
            <subLine>- UnityAds; </subLine> <br>
    
            •	Можно добавлять различные карты. Карта выбирается рандомно в начале игры. <br>
            •	Можно добавлять различные объекты наносящие урон. <br> <br>
            
            Имеется 2 сцены: <br>
            1 сцена – загрузочная. <br>
            2 сцена – геймплей + стартовое окно(ввиду небольшого проекта, а так можно было бы вынести в другую сцену). <br>

            <h3 align = "left"> Архитектура:  </h3> 

            <h4 align = "left"> Стек:  </h4> 
            •	Unity 2020.3.32f1, EcsLeo , UniLeo, Zenject, RemoteConfig, UnityAds. <br>
         
            <h4 align = "left"> Многоступенчатая система загрузки сцены </h4>

            Для асинхронной загрузки сцен применяются корутины. Cистемы отвечающие за загрузку системы разделены по уровням: <br>
            BootstrapExecutor – отвечает за последовательность загрузки глобальных блоков. <br>
            ICustomInstallersExecutor – отвечает за последовательность загрузки Custom Components;
            ICustomEventsLoader - отвечает за последовательность загрузки Custom Events;
            Ecs, Systems – отвечают за последовательность инициализации систем и порядок вызова систем в каждом кадре.

            <h5 align = "left"> Порядок загрузки сцены </h5>
            1.	Связывание зависимостей в Zenject; <br>

            <h5 align = "left">  Awake </h5>
           
            3.	ISceneBootstrapper(загрузчик сцены): <br>
            <subLine>Enter() – действия при входе в сцену; </subLine> <br>
            <subLine>Добаление загрузчиков в Bootstrap Executor(контролирует порядок загрузки Bootstrappers)  </subLine> <br>
            <subLine> Exit() - действия при выходе с сцены; </subLine> <br>
            
            4.	InstallersBootsrapper(загрузчик Custom компонентов); <br>
            <subLine>  Custom компоненты – независимые Services, Views; </subLine> <br>

            5.	EventsBootsrapper(загрузчик Custom Events); <br>
            <subLine>  Custom Events – место где взаимодействуют независимые Custom компоненты.</subLine>  <br>
            <subLine>   Типы: </subLine> <br>
            <subLine>  Event – обычное событие которое имеет однонаправленное выполнение, Execute().</subLine> <br>
            <subLine>  DualEvent – событие может быть отменено. Execute(), Undo();</subLine> <br>
            <subLine> Допустим Открыть какое то окно, которое параллельно еще +100500 внешних компонентов  задействует , а потом аккуратно закрыть его обратно, откатив нужные нам внешние компоненты обратно.</subLine> <br> <br>
           
            6.	EcsBootstrapper (загрузчик Ecs, в сценах с геймплеем); <br>
            7.	Последний Bootstrapper зависит от того, что нужно сделать после загрузки всей системы. Допустим если мы на сцене загрузки
            , то нужно загрузить сцену Геймплея. Если на сцене Геймплея, то нужно начать игру. <br>
            
            <h5 align = "left">  Start </h5>
            8.	Создание префабов в фабриках(модифицировано в следующем проекте TestProject1, в котором создание префабов происходит не в Start
            , а уже является продолжением общей загрузки системы в Awake, т.е. там уже есть возможность выбора последовательности инициализации фабрик); <br> <br>
            В общем сначала загружаются независимые компоненты(views, services), затем события, где эти компоненты взаимодействуют, в ecs  загружается геймплейная логика. 
            
            <h4 align = "left">  Архитектурная конфигурация сцены </h4>
            <subLine> •	CustomComponents подключаются к сцене путем размещения Installers в SceneContext(GameObject), нужно прокинуть связь в MonoInstaller. </subLine> <br>
            <subLine> •	CustomEvents подключаются к сцене в SceneEventsInstaller(Script); </subLine> <br>

            <h4 align = "left">  Архитектурная конфигурация ECS </h4>
            <h5 align = "left">  EcsLeo </h5> 
            1.	Данные(settings), ссылки на Services и CustomEvents, Views пробрасываются через SceneData, SceneServies, SceneViews соотвественно. <br>
            2.	Имеется две системы UpdateSystem, FixedUpdateSystem для разделения физики и обычных систем; <br>
            3.	Имеются следующие типы систем: <br>
            <subLine>•	IEcsPreInit – аналог Awake – ступень PreInit; </subLine> <br>
            <subLine>• IEcsInit – инициализация после PreInit;</subLine> <br>
            <subLine>•	IEcsRun – системы выполняющиеся каждый кадр; </subLine> <br>
            <subLine> •	IEcsRun OneFrame Events – системы выполняющиеся при необходимости только один раз на одном кадре; </subLine> <br>

            4.	Как правило системы в физике выполняются каждый кадр, а обычные системы как OneFrame; <br>
            5.	Компоненты:  <br>
            <subLine> •	Component – содержат данные; </subLine> <br>
            <subLine>•	Tag – просто помечают объект на сцене; </subLine> <br>
            <subLine> •	Event – обозначают начало события; </subLine> <br>

            6.	Триггерные события на сцене передаются в ECS через Triggers, которые добавляют в Entity нужный EventComponent. <br>
            7.	Начальные сущности создаются в Init системах в Ecs, фабриках, а так же на сцене с помощью UniLeo. <br>
            Создание сущности на сцене(нужные gameObjects, prefabs) – добавляется ComponentProvider(представитель Ecs Компонента на сцене Unity) на gameObject.
            Далее внутри фреймворка UniLeo, на стадии PreInit, осуществляется поиск на сцене gameObjects, содержащих ConvertToEntity
            компонент(компонент на объекте обозначающий, что его нужно конвертировать в сущность), далее создается сущность на основании добавленных компонентов. <br>
            В следующем проекте TestProject1 эта система была переделана, где на базе фреймворка UniLeo я сделал кастомное аналогичное решение,
             но уже там есть возможность выбора времени инициализации сущности на сцене, что удобно при создании префабов. <br> <br>
            
             <h4 align = "left">  Реализация CustomComponents  </h4>

             <subLine> </subLine> <br>
             <subSubLine> </subSubLine> <br>

            1.	Installer (MonoInstaller) <br>
            <subLine>Связывание зависимости (Zenject). </subLine> <br>
            <subLine>Инициализация внутренних модулей, установка внутренних зависимостей между модулями, доставка компоненту Settings с редактора Unity. </subLine> <br>
    
            2.	Дальнейшие этапы зависят от того, что реализуется: <br>
            <subLine>•	Services – реализация сервиса. </subLine> <br>
            <subLine> •	View - если View имеет какие-то внутренние данные, то реализация в MVP, если это просто View, которое не имеет собственных данных
                , то реализация как IView(без избыточного Presenter); </subLine> <br>
                
                 В целом в формате MVP обязанности модулей: <br>
                <subLine>- Model – данные модуля, их обработка, доступ к данным; </subLine> <br>
                <subLine>- View (MonoBehaviour) – ссылки на внешние элементы управления View(кнопки, TuchElements), функции изменения внешнего вида и т.д. </subLine> <br>
                <subLine>- Presenter – связывает View и Model, чаще всего взаимодействие реализуется паттерном Наблюдатель. Предоставляет интерфейс для взаимодействия с компонентом извне.</subLine> <br>


                <h4 align = "left"> Важные Custom компоненты </h4>
         
            •	ISaveDataService  <br>
            <subLine>  - void SubscribeToSaveEvent(Action observer); </subLine> <br>
            <subLine> - void UnsubscribeFromSaveEvent(Action observer); </subLine> <br>
            <subLine> - ref SaveData GetData(); </subLine> <br>
            <subLine> Слушатели подключаются на этапе загрузки проекта. В момент сохранения, те кому нужно сохраниться подтягиваются автоматически сами. </subLine> <br>

            •	IInternetConnectionService <br>
            <subLine>void CheckInternetConnection([CanBeNull] Action thenHasInternetConnection, [CanBeNull] Action thenHasNotInternetConnection); </subLine> <br>
            
            •	ICustomScenesLoader()  <br>
            <subLine> void LoadScene(ScenesNaming sceneNaming); </subLine> <br>
            <subLine> IEnumerator LoadSceneAsync(ScenesNaming sceneNaming, ISceneBootstrapper currentSceneBootstrapper); </subLine> <br> <br>
      	        
            Все Custom компоненты находятся в директории Services/CustomUI. <br>
            
            <h4 align = "left">  Тесты производительности  на устройстве Android, Honor 9A.  </h4>
            <p><a href="https://github.com/russellGadel/CoolGameBeFaster/tree/Develop/ReadmeAssets/ProfilerData">Profiler.</a></p>
            <p><a href="https://github.com/russellGadel/CoolGameBeFaster/tree/Develop/ReadmeAssets/MemoryProfilerData"> Memory Profiler;</a></p>
        </div>
    </body>
</html>


