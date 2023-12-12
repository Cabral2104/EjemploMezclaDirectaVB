Module Module1
    Function LeerDatos() As Integer()
        Dim input As String = Console.ReadLine()
        Dim elementos As String() = input.Split(" "c)
        Dim datos As Integer() = New Integer(elementos.Length - 1) {}

        For i As Integer = 0 To elementos.Length - 1
            datos(i) = Convert.ToInt32(elementos(i))
        Next

        Return datos
    End Function

    Sub MostrarDatos(datos As Integer())
        For Each elemento In datos
            Console.Write(elemento & " ")
        Next
        Console.WriteLine()
    End Sub

    Sub MezclaDirecta(datos As Integer(), izquierda As Integer, derecha As Integer)
        If izquierda < derecha Then
            Dim medio As Integer = (izquierda + derecha) \ 2

            ' Dividir la lista en dos mitades y ordenar cada mitad
            MezclaDirecta(datos, izquierda, medio)
            MezclaDirecta(datos, medio + 1, derecha)

            ' Combinar las dos mitades ordenadas
            Combinar(datos, izquierda, medio, derecha)
        End If
    End Sub

    Sub Combinar(datos As Integer(), izquierda As Integer, medio As Integer, derecha As Integer)
        Dim n1 As Integer = medio - izquierda + 1
        Dim n2 As Integer = derecha - medio

        ' Crear arreglos temporales
        Dim izquierdaArray As Integer() = New Integer(n1 - 1) {}
        Dim derechaArray As Integer() = New Integer(n2 - 1) {}

        ' Copiar datos a los arreglos temporales
        For i As Integer = 0 To n1 - 1
            izquierdaArray(i) = datos(izquierda + i)
        Next
        For j As Integer = 0 To n2 - 1
            derechaArray(j) = datos(medio + 1 + j)
        Next

        ' Fusionar los arreglos temporales
        Dim indiceIzquierda As Integer = 0, indiceDerecha As Integer = 0
        Dim indiceActual As Integer = izquierda

        While indiceIzquierda < n1 AndAlso indiceDerecha < n2
            If izquierdaArray(indiceIzquierda) <= derechaArray(indiceDerecha) Then
                datos(indiceActual) = izquierdaArray(indiceIzquierda)
                indiceIzquierda += 1
            Else
                datos(indiceActual) = derechaArray(indiceDerecha)
                indiceDerecha += 1
            End If
            indiceActual += 1
        End While

        ' Copiar los elementos restantes de izquierdaArray, si los hay
        While indiceIzquierda < n1
            datos(indiceActual) = izquierdaArray(indiceIzquierda)
            indiceIzquierda += 1
            indiceActual += 1
        End While

        ' Copiar los elementos restantes de derechaArray, si los hay
        While indiceDerecha < n2
            datos(indiceActual) = derechaArray(indiceDerecha)
            indiceDerecha += 1
            indiceActual += 1
        End While
    End Sub

    Sub Main()
        Console.WriteLine("Algoritmo de Mezcla Directa en Visual Basic")

        Do
            ' Solicitar al usuario que ingrese los datos
            Console.Write("Ingrese los elementos separados por espacio: ")
            Dim datos As Integer() = LeerDatos()

            ' Mostrar datos ingresados
            Console.WriteLine("Datos ingresados:")
            MostrarDatos(datos)

            ' Obtener la hora de inicio
            Dim startTime = DateTime.Now

            ' Medir el tiempo de ejecución
            Dim stopwatch = System.Diagnostics.Stopwatch.StartNew()

            ' Aplicar el algoritmo de mezcla directa
            MezclaDirecta(datos, 0, datos.Length - 1)

            ' Detener el temporizador
            stopwatch.Stop()

            ' Mostrar los datos ordenados
            Console.WriteLine("Datos ordenados:")
            MostrarDatos(datos)

            ' Obtener la hora de finalización
            Dim endTime = DateTime.Now

            ' Mostrar tiempo de inicio, tiempo de finalización y tiempo total de ejecución en segundos
            Console.WriteLine($"Tiempo de inicio: {startTime}")
            Console.WriteLine($"Tiempo de finalización: {endTime}")
            Console.WriteLine($"Tiempo total transcurrido: {stopwatch.Elapsed.TotalSeconds:F10} segundos")

            ' Preguntar al usuario si desea agregar más números
            Console.Write("¿Desea ingresar más números? (s/n): ")
        Loop While Console.ReadLine() = "s"
        Console.ReadKey()
    End Sub
End Module


