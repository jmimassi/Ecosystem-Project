# ProjetEcosyst

Ce projet a pour but de simuler un écosystème, qui, basé sur une suite de classe va nous permettre de donner aux entités présentes dans le programme certain comportement que nous pouvons moduler pour recréer l'environnement d'un écosystème. Dans notre cas, nous avons initié cet écosystème à un ensemble d'ours, de brebis et d'herbe.

Pour réaliser cet écosystème, nous avons choisi d'utiliser le langage C#.

## Subdivision du code :
Le but de ce code étant de créer un ensemble de classe pour simuler un écosystème, la structure de notre code s'est donc réalisé en se basant sur une arborescence de classe abstraite et d'héritage, celle-ci est détaillée dans le diagramme de classe ci-dessous :


![diag_classe_projet](https://user-images.githubusercontent.com/78797911/147883231-0345cfb2-2dc6-449c-9cf4-0eda6c3d011d.png)

## Démarrage de l'application :
Lancer le projet sur votre IDE, le programme étant initalisé pour simuler un monde avec des ours, brebis et herbe afin de débuter la simulation, le programme vous demandera de rentrer un nombre d'ours, de brebis et d'herbe ainsi que le nombre d'update de simulation voulu, image du temps passée dans la simulation.
Une fois les informations rentrées, la simulation se lancera et mettra à jour les informations des diverses entités et s'arrêtera apres le bon nombre d'update effectué.

## Explications du comportements des entités : 
Les méthodes Hunt implémentées se basent sur la détection des entités autour de l'animal dit chasseur. En effet, il demande à la simulation qui représente l'écosystème de lui fournir la liste des entités se trouvant autour de lui et juge du comportement à prendre en fonction du type d'entité autour de lui. 
Pour les ours, l'animal vérifie premièrement si il n'a pas de viande dans son rayon de vision, si c'est le cas, celui-ci se déplace vers elle si elle ne se situe pas dans sa zone de contact. Sinon, elle la mange afin de récupérer des points d'énergie (EP).
Si il n'a pas de viande à proximité, il vérifie la présence d'herbivore, et adopte la même stratégie sauf qu'il commence par attaquer l'herbivore à la place de le manger.
Si il n'y a aucun des 2 à proximité, celui-ci cherche de potentiel partenaires sexuels afin de se reproduire. Si aucune entité n'est autour de l'animal, celui-ci se déplace au hasard.

Les brebis adoptent le même comportement sauf que celle-ci chassent les plantes et non les herbivores.

L'herbe ne pouvant pas de déplacer, elle n'a que pour option que de consommer les matières organiques présentes autour de elle ou de se reproduire. La reproduction de l'herbe se fait de manière asséxuée, ce qui signifie que celle-ci se reproduit même seule. L'herbe se reproduit seule tout les 3 tours.

La viande elle, ne fait que rester au même endroit. Si elle n'est pas consommée au bout de 5 tours, elle se transforme en matière organique. 

Finalement, la matière organique elle, ne fait que rester au même endroit sans jamais changer d'état. 

## Ajout d'une nouvelle espèce :
Pour rajouter une nouvelle espèce, il faut commencer par créer une classe héritant de la classe abstraite souhaitées : 
- Un Carnivore
- Un Herbivore
- Une Plante

Une fois cela fait, il faudra créer un constructeur pour cette classe. Par la suite, il faudra redéfinir les méthodes Reproduce et Hunt de manière à simuler au mieux le comportement de l'animal. La méthode Hunt par défaut ne contient pas de méthode de reproduction et la méthode Reproduce elle n'est pas implémentée par défaut.

## Respect des principes SOLID : 
- Liskov :  

Les classes héritées respectent le principe car on ne peut appeler uniquement les dernières classes.  
Ces classes servent à détailler celles dont elles héritent, tout en redéfinissant certaines méthodes.  
Cela signifie donc que si on avait une instance d’une classe mère, elle serait automatiquement remplaçable par une instance de la classe fille. 

- Single responsability :  

Nos classes ont comme pour seul but que de simuler leurs comportements respectifs, à l’exception de la classe simulation qui elle a pour but de simuler un écosystème plus en général. 


## Dépendances :
1) .NET 6.0


Projet réalisé en binôme par Rayane Saïdi(195048) et Mimassi Joseph(195178).
