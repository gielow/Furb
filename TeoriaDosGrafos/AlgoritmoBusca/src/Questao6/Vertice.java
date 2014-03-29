//DANIEL GIELOW JUNIOR

package Questao6;

import java.util.ArrayList;
import java.util.List;

public class Vertice {
	
	private String nome;
	private List<Vertice> adjacencias;
	
	public Vertice(String nome)	{
		this.setNome(nome);
		this.adjacencias = new ArrayList<Vertice>();
		
	}
	public List<Vertice> getAdjacencias(){
		return this.adjacencias;
	}
	public void setAdjacencias(Vertice...adjacencias){
		for(Vertice adjacencia : adjacencias){
			this.adjacencias.add(adjacencia);
		}
	}
	
	public String getNome() {
		return nome;
	}
	private void setNome(String nome) {
		this.nome = nome;
	}
	
	public String toString(){
		return getNome();
	}
}
