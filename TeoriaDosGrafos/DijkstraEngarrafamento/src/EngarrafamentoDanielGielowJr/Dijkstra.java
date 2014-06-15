//DANIEL GIELOW JUNIOR
package EngarrafamentoDanielGielowJr;

import java.util.PriorityQueue;
import java.util.List;
import java.util.ArrayList;
import java.util.Collections;

public class Dijkstra
{
    public static Caminho obterCaminho(Vertice origem, Vertice destino)
    {
    	PriorityQueue<Vertice> fila = new PriorityQueue<Vertice>();
    	
    	origem.distanciaMinima = 0;
    	fila.add(origem);

      	while (!fila.isEmpty()) {
      		Vertice u = fila.poll();

            for (Aresta e : u.adjacencias)
            {
            	Vertice v = e.verticeDestino;
                int pesoAresta = e.peso;
                int distanciaParaU = u.distanciaMinima + pesoAresta;
				if (distanciaParaU < v.distanciaMinima) {
					fila.remove(v);
				    v.distanciaMinima = distanciaParaU;
				    v.anterior = u;
				    fila.add(v);
				}
            }
        }
      	
      	List<Vertice> vertices = new ArrayList<Vertice>();
        for (Vertice vertice = destino; vertice != null && vertice.distanciaMinima != Integer.MAX_VALUE; vertice = vertice.anterior)
        	vertices.add(vertice);
        Collections.reverse(vertices);
        return new Caminho(vertices, destino.distanciaMinima);
    }
}