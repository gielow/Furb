//DANIEL GIELOW JUNIOR

package Questao6;

public class ElementoVetorRoteamento {
	private Vertice verticePai;
	private Integer tempo;
	
	public ElementoVetorRoteamento(){
	}
	public ElementoVetorRoteamento(Vertice verticePai, Integer tempo){
		setVerticePai(verticePai);
		setTempo(tempo);
	}

	public Vertice getVerticePai() {
		return verticePai;
	}
	public String getVerticePaiFormatado() {
		return verticePai != null? verticePai.toString() : "nil";
	}
	public void setVerticePai(Vertice verticePai) {
		this.verticePai = verticePai;
	}
	public Integer getTempo() {
		return tempo;
	}
	public String getTempoFormatado() {
		return tempo != null? tempo.toString() : "∞";
	}
	public void setTempo(Integer tempo) {
		this.tempo = tempo;
	}	
}