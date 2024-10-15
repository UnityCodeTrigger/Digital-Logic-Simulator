# Digital-Logic-Simulator
Proyecto final de curso de programacion basica con Java y C#.
En este proyecto hice un simulador de puertas logicas donde puedes crear tus propias puertas logicas y combinarlas infinitamente, la capacidad de calculo maxima que he probado ha sido una calculadora binaria basica.
![NAND](https://github.com/user-attachments/assets/ea3928d7-1057-4b24-addd-f4c33465183d)

## Como se renderiza el programa?
He usado la libreria *System.Drawing* la cual te permite dibujar figuras basicas como rectangulos, circulos y lineas.<br>
Los componentes son rectangulos que se renderizan cada vez que hay un cambio en pantalla, el texto tambien se dibuja junto a los componentes.<br>
El orden de renderizado es:
- Fondo
- Componentes
- Nombres de componentes
- Conexiones
- Componentes fantasma (Efecto de arrastrar un componente para previsualizarlo al crearlo)


## Ejemplos y compilacion de Componentes
Compile format:<br>
{NAME}, {AUTHOR}, {NUMBER_INPUTS}, {NUMBER_OUTPUTS}, {HUE (color tone)}, {TRUTH_TABLE (only positive outputs for optimization)}<br>

### OR Gate Example:
![image](https://github.com/user-attachments/assets/cb853281-26e7-4177-b0c5-9337a082face)
![image](https://github.com/user-attachments/assets/560d9e83-e35a-47db-ad06-62d16c1ce673)
<br>

#### AND Gate
.AND,base,2,1,0.5,111<br>
1,1 = 1 **(111)**<br>
*any other configuration is = 0*<br>

#### NAND Gate
NAND,AuthorName,2,1,0,001011101<br>
0,0 = 1 **(001)**<br>
0,1 = 1 **(011)**<br>
1,0 = 1 **(101)**<br>
*any other configuration is = 0*<br>
