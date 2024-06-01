void bienvenido()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(@"

                .
                                         .☆... ︵.☆.................. ︵  ☆... ︵.☆.................. ︵
¸☆( ░░░)︵ ︵☆¸☆( ░░░)︵ ︵                    ☆( ░░░)︵ ︵☆¸☆( ░░░)︵ ︵
(´░░░░░░░░'.)(´░░░░░░░░'.)                        (´░░░░░░░░'.)(´░░░░░░░░'.)
..`´︶´¯`︶´`´..........`´︶´¯`︶´`´              ..`´︶´¯`︶´`´..........`´︶´¯`︶´`´
`,..``,.``,..``,.``,..``,.``,..``,.``,..``,.``,..``,.``,..``,.``,..``,.``,..``,.``,..``,.``,..``,.``,..``,.`
`,.`.`,.``,..``,.``,..``,.``,..``,.``,..``,.``,..``,.``,..``,.``,..``,.``,..``,.``,..``,.``,..``,.``,..``,.`
~~~~~~▄███████▄~~~~~~`,..``,.``,..``,.``,..``,.``,..``,.``,..``,.``,..``,.``,..``,.``,..``,.``,..``,.``,...``,..``,.``,..``,.``  
~~~~~▄█▄█▄█▄█▄█▄▄~~~~~                                                              
~~▀███████████████▀─~                                     ──────▄──▄──▄──────
                                                           ────║─▓──▓──▓──────
.``,..``,.``,..``,.``               .``,..``,.``,..``,.``  ────░░░░░░░░░░─────
                                                            ▀███████████████▀──   ,..``,.``,...``,..``,.``,..``,.`` 
                                                            ───────────────────
                          ▀▀▀▄░▄▄░░▄▀▄▄▄░░              ~~~~~~~~~~~~~~~~~~~~~~~
.``,..``,.``,..``,.``     ▀▀▀▄░▄▄░░▄▀▄▄▄░░
                          ▄▀▀▄█▄░▀░▄▀█▄░▀▄
                         ░░░░█░▀░▀░░ █░▀▄░                                ,..``,.``,...``,..``,.``,..``,.`` 
                          ██████▄▄▄██████▄                           

                                  ~~~~~~▄███████▄                ,..``,.``,...``,..``,.``,..``,.`` 
                                  ~~~~~▄█▄█▄█▄█▄█▄▄
       .``,.``,..``,.``            ~~▀███████████████▀~
                                   ~~~~~~~~~~~~~~~~~~~~~~~~ 
                                                                        
                    
                      ***********************************BATTLESHIP********************************

                           

                 Prepárate para una batalla épica en el mar, donde tu astucia y estrategia serán puestas a prueba. 

         Disfruta de este clásico juego de hundir barcos, ahora con símbolos para una experiencia aún más emocionante.

                                              ¡SU NACIÓN CONFIA EN USTED CAPITÁN!
        ");
    Console.ResetColor();
}
bienvenido();

int longitud_tablero()

{

    int n = 0;
    do
    {

        Console.WriteLine("Ingrese la longitud del tablero, primero fila da un enter y luego la columna , -1 para salir del programa");
        if (!int.TryParse(Console.ReadLine(), out int nuevo1))
        {
            Console.WriteLine("Error: debe ingresar un número diferente a 0, no se permiten caracteres.");
        }
        else if (nuevo1 == -1)
        {
            return -1;
        }
        else if (nuevo1 <= 0)
        {
            Console.WriteLine("Error: la longitud ingresada debe ser mayor que 0.");
        }
        else
        {
            n = nuevo1; // Actualiza el valor de n
        }
    } while (n <= 0);

    return n;
}

int[,] tablero = new int[longitud_tablero(), longitud_tablero()];

void paso1_crear_tablero(int[,] tablero)
{


    for (int f = 0; f < tablero.GetLength(0); f++)
    {
        for (int c = 0; c < tablero.GetLength(1); c++)
        {
            tablero[f, c] = 0;
        }
    }
}



void paso2_colocar_barcos(int[,] tablero)
{

    int total_celdas = tablero.GetLength(0) * tablero.GetLength(1);
    int cantidad_barcos = total_celdas / 2;
    int barcos_colocados = 0;

    Random ale = new Random();

    while (barcos_colocados <= cantidad_barcos)
    {
        int x = ale.Next(0, tablero.GetLength(0));
        int y = ale.Next(0, tablero.GetLength(1));

        if (tablero[x, y] != 1)
        {

            tablero[x, y] = 1;
            barcos_colocados = barcos_colocados + 1;
        }
    }


}

void paso3_imprimir_tablero(int[,] tablero)
{
    int filas = tablero.GetLength(0);
    int columnas = tablero.GetLength(1);

    // Imprimir encabezado de columnas
    Console.Write("  ");
    for (int c = 0; c < columnas; c++)
    {
        Console.Write(c + " ");
    }
    Console.WriteLine();

    // Imprimir línea separadora
    Console.Write("  ");
    for (int c = 0; c < columnas; c++)
    {
        Console.Write("= ");
    }
    Console.WriteLine();

    for (int f = 0; f < filas; f++)
    {
        // Imprimir encabezado de filas
        Console.Write(f + "|");

        for (int c = 0; c < columnas; c++)
        {
            string caracter_a_imprimir = "";
            switch (tablero[f, c])
            {
                case 0:
                    caracter_a_imprimir = "~";
                    break;

                case 1:
                    caracter_a_imprimir = "~";
                    break;

                case -1:
                    caracter_a_imprimir = "*";
                    break;

                case -2:
                    caracter_a_imprimir = "X";
                    break;

                default:
                    caracter_a_imprimir = "~";
                    break;
            }
            Console.Write(caracter_a_imprimir + " ");
        }
        Console.WriteLine();
    }
}
void paso4_ingreso_coordenadas(int[,] tablero)
{
    int intentos_restantes = (tablero.GetLength(0) * tablero.GetLength(1)) / 4; // Dividir entre 4 para tener la mitad de intentos que la cantidad de celdas
    int barcos_restantes = (tablero.GetLength(0) * tablero.GetLength(1)) / 2;
    int puntuacion = 0;
    int intentos = 0;

    Stopwatch reloj = new Stopwatch();
    reloj.Start();

    while (barcos_restantes > 0 && intentos_restantes > 0)
    {
        Console.Write("Ingresa la fila: ");
        if (!int.TryParse(Console.ReadLine(), out int fila) || fila < 0 || fila >= tablero.GetLength(0))
        {
            Console.WriteLine("Error: fila inválida. Intenta de nuevo.");
            continue;
        }

        Console.Write("Ingresa la columna: ");
        if (!int.TryParse(Console.ReadLine(), out int columna) || columna < 0 || columna >= tablero.GetLength(1))
        {
            Console.WriteLine("Error: columna inválida. Intenta de nuevo.");
            continue;
        }

        if (tablero[fila, columna] == -1 || tablero[fila, columna] == -2)
        {
            Console.WriteLine("Ya has intentado en esta posición. Intenta de nuevo.");
            continue;
        }

        if (tablero[fila, columna] == 1)
        {
            Console.Beep();
            Console.WriteLine("¡Acertaste un barco!");
            tablero[fila, columna] = -1;
            intentos_restantes++;
            barcos_restantes--;
            puntuacion += 10;
            intentos++;
        }
        else
        {
            Console.WriteLine("Agua.");
            tablero[fila, columna] = -2;
            intentos_restantes--;
            puntuacion--;
            intentos++;
        }

        Console.WriteLine("Intentos restantes: " + intentos_restantes);
        Console.WriteLine("Barcos restantes: " + barcos_restantes);
        Console.WriteLine("Puntuación actual: " + puntuacion);
        paso3_imprimir_tablero(tablero);
    }

    reloj.Stop();

    if (barcos_restantes == 0)
    {











        Console.WriteLine(@"
────────────────────░███░
───────────────────░█░░░█░
──────────────────░█░░░░░█░
─────────────────░█░░░░░█░
──────────░░░───░█░░░░░░█░
─────────░███░──░█░░░░░█░
───────░██░░░██░█░░░░░█░
──────░█░░█░░░░██░░░░░█░
────░██░░█░░░░░░█░░░░█░
───░█░░░█░░░░░░░██░░░█░
──░█░░░░█░░░░░░░░█░░░█░
──░█░░░░░█░░░░░░░░█░░░█░
──░█░░█░░░█░░░░░░░░█░░█░
─░█░░░█░░░░██░░░░░░█░░█░
─░█░░░░█░░░░░██░░░█░░░█░
─░█░█░░░█░░░░░░███░░░░█░
░█░░░█░░░██░░░░░█░░░░░█░
░█░░░░█░░░░█████░░░░░█░
░█░░░░░█░░░░░░░█░░░░░█░
░█░█░░░░██░░░░█░░░░░█░
─░█░█░░░░░████░░░░██░
─░█░░█░░░░░░░█░░██░█░
──░█░░██░░░██░░█░░░█░
───░██░░███░░██░█░░█░
────░██░░░███░░░█░░░█░
──────░███░░░░░░█░░░█░
──────░█░░░░░░░░█░░░█░
──────░█░░░░░░░░░░░░█░
──────░█░░░░░░░░░░░░░█░
──────░█░░░░░░░░░░░░░█░
████──░█░████░░░░░░░░█░
█──█──████──████░░░░░█░
█──█──█──█──█──████████
█──█──████──█──█──────█
█──█──█──█────██──██──█
█──████──█──█──█──────█
█─────█──█──█──█──█████
███████──████──█──────█
──────████──██████████
★══════════★★══════════★");



        Console.WriteLine("¡Felicidades! Has hundido todos los barcos en " + reloj.Elapsed + "  Minutos");
        Console.WriteLine("Tu puntuación es: " + puntuacion);
        Console.WriteLine("Tus intentos totales fueron: " + intentos);
    }
    else
    {
        Console.WriteLine("¡Has perdido! No te quedan más intentos.");
        Console.WriteLine("usaste : " + intentos + " intentos ");
    }

    Console.WriteLine("Presiona 1 para jugar otra vez o cualquier otra tecla para salir.");
    string opcion = Console.ReadLine();
    if (opcion == "1")
    {
        // Reiniciar el juego llamando a la función principal de nuevo.
        tablero = new int[longitud_tablero(), longitud_tablero()];

        paso1_crear_tablero(tablero);
        paso2_colocar_barcos(tablero);
        paso3_imprimir_tablero(tablero);
        paso4_ingreso_coordenadas(tablero);
    }
    else
    {
        // Salir del juego.
        Environment.Exit(0);
    }
}



paso1_crear_tablero(tablero);
paso2_colocar_barcos(tablero);
paso3_imprimir_tablero(tablero);
paso4_ingreso_coordenadas(tablero);