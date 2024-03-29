//DANIEL GIELOW JUNIOR

package Questao6;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class AlgoritmosDeBusca {
	
	public VetorRoteamento buscarEmProfundidade(Grafo grafo){
		Map<Vertice, String> cor = new HashMap<Vertice, String>();
		Map<Vertice, Integer> d = new HashMap<Vertice, Integer>();
		Map<Vertice, Integer> f = new HashMap<Vertice, Integer>();
		
		VetorRoteamento vetorRoteamento = new VetorRoteamento(grafo);
		Tempo tempo = new Tempo();
		
		for(Vertice u : grafo.getVertices())
		{
			System.out.println("Marcando o vertice " + u +" com a cor Branca");
			cor.put(u, "BRANCO");
		}
		
		for(Vertice u : grafo.getVertices())
		{
			if(cor.get(u) == "BRANCO")
			{
				visitarVertice(u, vetorRoteamento, cor, d, f, tempo);
			}
		}
		
		return vetorRoteamento;
	}
	
	private void visitarVertice(Vertice u, VetorRoteamento vetorRoteamento, Map<Vertice, String> cor, Map<Vertice, Integer> d, Map<Vertice, Integer> f, Tempo tempo)
	{
		System.out.println("Visitando o vertice " + u);
		
		cor.put(u, "CINZA");
		tempo.adicionarUm();
		d.put(u, tempo.getTempo());
		
		vetorRoteamento.setTempoVertice(u, tempo.getTempo());
		for(Vertice v : u.getAdjacencias())
		{
			System.out.println("Adjacencia do vertice " + u + ":" + v);
			if(cor.get(v) == "BRANCO"){
				vetorRoteamento.setPaiVertice(v, u);
				visitarVertice(v, vetorRoteamento, cor, d, f, tempo);
			}
		}
		cor.put(u, "PRETO");
		tempo.adicionarUm();;
		f.put(u, tempo.getTempo());
	}
	
	public VetorRoteamento buscarEmLargura(Grafo grafo){
		return buscarEmLargura(grafo, grafo.getVertices().get(0));
	}
	
	public VetorRoteamento buscarEmLargura(Grafo grafo, Vertice verticeInicial){
		Map<Vertice, String> cor = new HashMap<Vertice, String>();
		VetorRoteamento vetorRoteamento = new VetorRoteamento(grafo);
		
		for(Vertice u : grafo.getVertices())
		{
			cor.put(u, "BRANCO");
		}
		
		cor.put(verticeInicial, "CINZA");
		vetorRoteamento.setTempoVertice(verticeInicial, 0);
		
		List<Vertice> q = new ArrayList<Vertice>();
		q.add(verticeInicial);
		
		while(q.size() > 0){
			Vertice u = q.remove(0);
			for(Vertice v : u.getAdjacencias()){
				if(cor.get(v) == "BRANCO"){
					q.add(v);
					cor.put(v, "CINZA");
					vetorRoteamento.setPaiVertice(v, u);
					vetorRoteamento.setTempoVertice(v, vetorRoteamento.getTempoVertice(u) + 1);
				}
			}
			cor.put(u, "PRETO");
		}
		
		return vetorRoteamento;
	}
}
