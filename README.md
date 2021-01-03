# M1_Unity_Projet (Moise Resurrection 2)

Pour ce projet, j'ai décidé de partir sur un autre jeu (pas de Flappy Bird ni de shooter d'astéroïdes ici !)

J'ai l'honneur de vous présenter **Moïse Resurrection 2** !

(le premier Moise Resurrection est en réalité mon projet d'ISN en Terminale, un jeu avec Pygame, librairie Python, en groupe de 3)

Ce jeu est en 2D, de type Roguelike (inspiré par Enter the Gungeon, The Binding of Isaac, Hades, etc...).

## Ce qui a été intégré

- Menu principal avec musique de fond
- 3 niveaux différents (difficulté croissante = les ennemis sont plus forts)
- Classe `GameState` qui suit la progression du joueur à travers le jeu
- Scène GameOver unique, qui gère toutes les "fins" (le personnage meurt, gagne les niveaux 1, 2 et 3)
- Attaque personnage
- Animations personnage et ennemis
- Dash du joueur
- Barre de vie et barre de "temps avant prochaine attaque" (en bleu) au dessus de chaque ennemi
- Musique et bruitages
  

## Ce qui aurait dû être intégré

- Un rapport avec l'eau (quand on imagine Moïse on le voit séparer la mer en deux), lors du développement du jeu, j'avais voulu implémenter une transition avec une vague, qui, lorsque la scène suivante est chargée, se fait séparer en deux, pour laisser place à la scène suivante. Par manque de temps (et d'organisation 😅) je me suis donc tourné vers une transition simple (fondu au noir)
- Plusieurs types d'armes : actuellement, dans le jeu, il n'y a qu'une arme disponible. Il était prévu d'implémenter d'autres armes, chacune avec des dégats ou portées différents. Par manque de temps, je ne les ais pas implémentées.
- La possibilité de ramasser les armes des ennemis tués : à la base, quand un ennemi meurt, il devait laisser tomber au sol son arme. Le joueur pourrait alors échanger la sienne contre l'arme de sa victime. J'ai commencé à implémenter le fait de ramasser une arme, mais en voyant le reste du travail que j'avais à faire pour rendre ce que je vous rends aujourd'hui, j'ai laissé tomber cette idée.
- Une meilleure IA pour les ennemis : actuellement les ennemis foncent tête baissée dans les trous, je pense qu'il aurait été sympa que certains ennemis soient plus intelligents que d'autres en évitant les trous (pour permettre un peu de diversité). Cela aurait été utile dans le niveau 3, dans la une salle avec plein de grands trous. Les ennemis vont droit vers le joueur sans se soucier de leur environnement, et tombent dans les trous...

## Les difficultés rencontrées et comment vous êtes sortis de ces difficultés

### Création des niveaux (utilisation des Tilemaps)

 Je ne savais pas vraiment comment faire pour créer les niveaux. Au début, j'avais pensé faire plein de sprites pour chaque "case" du niveau. Mais je suis tombé sur [cette vidéo de Brackeys](https://www.youtube.com/watch?v=ryISV_nH8qw) et j'ai appliqué la méthode. C'est super de pouvoir peindre un niveau comme si on était sur Paint !

### Contrôles tactiles

 Au début, je testais mon jeu avec les touches du clavier. Mais le jeu est orienté mobile, et personnellement, je n'ai pas de clavier sur mon téléphone. J'ai donc cherché sur internet comment faire pour implémenter un joystick virtuel, et je suis tombé sur le Joystick Pack de l'Asset Store Unity. Ultra simple à utiliser, il fournit des prefabs pour les joystick, et on récupère les input avec `Joystick.Vertical` et `Joystick.Horizontal`.

### Trouver des sons et musiques adaptées + les utiliser

J'ai toujours trouvé difficile de trouver des bruitages et des musiques libres de droit, sans watermark... alors je me suis tourné vers l'Asset Store et j'ai acheté le Ultimate Sound FX Bundle, comme ça j'ai eu l'embaras du choix (merci les soldes de Noël). 
Ensuite, pour les mettre dans le jeu, j'ai suivi [ce tutoriel de Brackeys](https://www.youtube.com/watch?v=6OT43pvUyfY), et je peux vous dire que son AudioManager est très pratique.

### Attaque des ennemis

Je ne savais pas comment faire attaquer les ennemis, puis j'ai eu l'idée de leur implémenter une fréquence d'attaque (attaque toutes les X secondes). Le jeu était bien, mais les attaques des ennemis étaient imprévisibles. J'ai donc affiché une barre bleue au dessus de l'ennemi, qui représente le temps qu'il reste avant que l'ennemi attaque. Cela permet au joueur de prévoir l'attaque de l'ennemi afin d'esquiver les coups.

## Ressources utilisées
- Son : [Ultimate Sound FX Bundle](https://assetstore.unity.com/packages/audio/sound-fx/ultimate-sound-fx-bundle-151756)
- Code pour le joystick : [Joystick Pack](https://assetstore.unity.com/packages/tools/input-management/joystick-pack-107631)
- Images/animations pour ennemis/joueur/monde : [Dungeon Tileset 2](https://0x72.itch.io/dungeontileset-ii)
- Boutons in game : Kenny Game Assets - Onscreen Controls (partagé par un ami)

-- Pierre-Louis Bertrand
