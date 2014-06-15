//DANIEL GIELOW JUNIOR
package EngarrafamentoDanielGielowJr;

import java.util.List;

public class Caminho {
	private List<Vertice> caminho;
	private int distancia;
	
	public Caminho(List<Vertice> caminho, int distancia) {
		this.caminho = caminho;
		this.distancia = distancia;
	}
	
	public List<Vertice> getCaminho(){
		return this.caminho;
	}
	
	public int getDistancia(){
		return this.distancia;
	}
	
	@Override
	public String toString(){
		StringBuilder sbStr = new StringBuilder();
		sbStr.append("D: " + (distancia == Integer.MAX_VALUE? -1 : distancia) + " | ");
		
	    for (int i = 0; i < caminho.size(); i++) {
	        if (i > 0)
	            sbStr.append("->");
	        sbStr.append(caminho.get(i));
	    }
	    return sbStr.toString();
	}
}
