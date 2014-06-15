//DANIEL GIELOW JUNIOR
package EngarrafamentoDanielGielowJr;

import java.util.ArrayList;
import java.util.List;

class Vertice implements Comparable<Vertice>
{
    public final String nome;
    public List<Aresta> adjacencias;
    public int distanciaMinima = Integer.MAX_VALUE;
    public Vertice anterior;
    
    public Vertice(String nome) {
    	this.adjacencias = new ArrayList<Aresta>();
    	this.nome = nome; 
    }
    public String toString() { 
    	return "v"+nome; 
    }
    
    public int compareTo(Vertice other)
    {
        return Double.compare(distanciaMinima, other.distanciaMinima);
    }
}
