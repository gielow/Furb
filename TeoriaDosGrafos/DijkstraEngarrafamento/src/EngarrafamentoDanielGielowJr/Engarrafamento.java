//DANIEL GIELOW JUNIOR
package EngarrafamentoDanielGielowJr;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class Engarrafamento {
	
	public static List<Caminho> ObterCaminhos(StringBuilder sEntradas){
		List<String> entradas = new ArrayList<String>();
		for(String s: sEntradas.toString().split("\n")){
		    entradas.add(s);
		}
		return ObterCaminhos(entradas);
	}
	public static List<Caminho> ObterCaminhos(List<String> entradas){
		System.out.println("Entradas:");
		for(String entrada : entradas){
			System.out.println(entrada);
		}
		
		List<Caminho> caminhos = new ArrayList<Caminho>();
		int index = 0;
		 
		System.out.println();
		System.out.println("Saidas:");
		while(index < entradas.size() && !entradas.get(index).equals("0 0"))
		{
			String[] linhaEntrada = entradas.get(index).split(" ");
			int n = Integer.parseInt(linhaEntrada[0]);
			int m = Integer.parseInt(linhaEntrada[1]);
			index++;
			
			Map<Integer,Vertice> vertices = new HashMap<Integer, Vertice>();
			for(int j = 0; j < n; j++){
				Integer numeroVertice = j+1;
				vertices.put(numeroVertice, new Vertice(numeroVertice.toString()));
			}
			for(int j = 0; j < m; j++){
				String[] linhaAdjacencias = entradas.get(index).split(" ");
				int vOrigem = Integer.parseInt(linhaAdjacencias[0]);
				int vDestino = Integer.parseInt(linhaAdjacencias[1]);
				int peso = Integer.parseInt(linhaAdjacencias[2]);
				
				Vertice verticeOrigem =vertices.get(vOrigem);
				Vertice verticeDestino =vertices.get(vDestino);
				
				verticeOrigem.adjacencias.add(new Aresta(verticeDestino, peso));
				index++;
			}
			
			String[] linhaLocais = entradas.get(index).split(" ");
			int vInicial = Integer.parseInt(linhaLocais[0]);
			int vFinal = Integer.parseInt(linhaLocais[1]);
			
			Vertice verticeInicial = vertices.get(vInicial);
			Vertice verticeFinal = vertices.get(vFinal);
			
			Caminho caminho = Dijkstra.obterCaminho(verticeInicial, verticeFinal);
			System.out.println(caminho);
			caminhos.add(caminho);
			index++;
		}
		
		return caminhos;
		
	}
}
