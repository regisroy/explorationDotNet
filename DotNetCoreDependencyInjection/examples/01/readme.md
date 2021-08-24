# Injection de dépendeances avec Dot net core

## Pourquoi l'injection de dépendance
- principes SOLID (bonnes pratiques)
  - **S** : Single responsability principle : Principe de reponsabilité Unique
  - **O** : Open/Closed principle           : principe d'ouverture à l'extension / fermeture à la modification directe
  - **L** : Liskov substitution principle   : principe de substitution de Liskov
  - **I** : Interface segregation principle : principe de ségrégation des interfaces
  - **D** : Dependencyy injection           : principe d'injection de dépendance 

- Thèses
  - les modules de haut niveau ne doivent pas dépendre des modules de bas niveau
  - les abstractions ne doivent pas dépendre des détails. Les détails doivent dépendre des abstractions.

- permettre la modularité
- permettre plus aisément les tests à tous les niveaux
- amélioration de la conception
- permettre l'extensibilité
- permettre une maîtrises des détails

## Comment faire ?
- à la main
  - exemple le cas d'un controller rest qui doit récupérer des informations, calculer qqch et renvoyer le résultat.
    On utilise ici une architecture découpée en couches : Repository, Service, Controller
  - Exemple 1 : pas d'injection de dépendance
```c#
    public class Controller {
        private IDatabase database = new Database();
        private IRepository repository = new DbRepository(database);
        private IService service = new Service();
        private ISerializer serializer = new Serializer();
        
        public GetComputedInfos() {
            string infos = repository.getInfos();
            string computedinfos = service.compute(infos);
            return serializer.serialize(computedInfos);
        }
    }
    Controller controller = new Controller();
    controller.GetComputerInfos();
```
  - Exemple 2 : avec injection de dépendance
```c#
    public class Controller {
        private IRepository repository;
        private IService service;
        private ISerializer serializer;
        
        public Controller(IRepository repository, IService service, ISerializer serializer) {
            this.repository = repository; 
            this.service = service; 
            this.serializer = serializer; 
        }
        
        public GetComputedInfos() {
            string infos = repository.getInfos();
            string computedinfos = service.compute(infos);
            return serializer.serialize(computedInfos);
        }
    }
    IDatabase database = new Database();
    IRepository repository = new DbRepository(database);
    IService service = new Service();
    ISerializer serializer = new Serializer();
    
    Controller controller = new Controller(repository, service, serializer);
    controller.GetComputerInfos();
```
- avec un framework
  - Autofac
  - Unity
  - NInject
  - dotnet core
  - ...  
  - 
  - Exemple 3 : injection de dépendance avec dotnet core
    - cf. code

