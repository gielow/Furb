//DANIEL GIELOW JUNIOR

package Questao6;

import java.util.ArrayList;
import java.util.List;

public class Grafo {
	
	public Grafo()
	{
		vertices = new ArrayList<Vertice>();
	}
	
	public List<Vertice> getVertices()
	{
		return vertices;
	}
	
	private List<Vertice> vertices;

	public void adicionarVertices(Vertice... vertices) {
		for(Vertice vertice : vertices){
			System.out.println("Adicionando o vertice " + vertice + " no grafo.");
			this.vertices.add(vertice);
		}
	}
}
