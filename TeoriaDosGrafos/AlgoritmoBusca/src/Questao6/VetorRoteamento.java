//DANIEL GIELOW JUNIOR

package Questao6;

import java.util.HashMap;
import java.util.Map;

public class VetorRoteamento {
	private Map<Vertice, ElementoVetorRoteamento> elementos;
	
	public VetorRoteamento(){
		this.elementos = new HashMap<Vertice, ElementoVetorRoteamento>();
	}
	public VetorRoteamento(Grafo grafo){
		this.elementos = new HashMap<Vertice, ElementoVetorRoteamento>();
		for(Vertice v : grafo.getVertices()){
			elementos.put(v, new ElementoVetorRoteamento());;
		}
	}
	public Map<Vertice, ElementoVetorRoteamento> getElementos() {
		return elementos;
	}
	public void setTempoVertice(Vertice v, Integer tempo) {
		ElementoVetorRoteamento elemento = elementos.get(v);
		elemento.setTempo(tempo);
	}
	
	public Integer getTempoVertice(Vertice v) {
		ElementoVetorRoteamento elemento = elementos.get(v);
		return elemento.getTempo();
	}

	public void setPaiVertice(Vertice v, Vertice vPai) {
		ElementoVetorRoteamento elemento = elementos.get(v);
		elemento.setVerticePai(vPai);
	}
	
	public String toString(){
		System.out.print(" |");
		for(Vertice v : elementos.keySet()){
			System.out.print(Strings.leftPad(v.toString(), 8) + "|");
		}
		System.out.println();
		System.out.print("π|");
		for(ElementoVetorRoteamento e : elementos.values()){
			System.out.print(Strings.leftPad(e.getVerticePaiFormatado().toString(), 8) + "|");
		}
		System.out.println();
		System.out.print("D|");
		for(ElementoVetorRoteamento e : elementos.values()){
			System.out.print(Strings.leftPad(e.getTempoFormatado().toString(), 8) + "|");
		}
		System.out.println();
		return "";
	}
}
