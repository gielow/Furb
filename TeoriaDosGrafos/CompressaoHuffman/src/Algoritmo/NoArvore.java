package Algoritmo;

import java.util.ArrayList;
import java.util.List;


public class NoArvore implements Comparable<NoArvore>{
	private int peso;
	private String valor;
	private String caminho;
	private NoArvore noEsquerdo;
	private NoArvore noDireito;
	
	public NoArvore(String valor, int peso){
		this.valor = valor;
		this.peso = peso;
		setarCaminho("");
	}
	
	public NoArvore(NoArvore noEsquerdo, NoArvore noDireito){
		this.valor = noEsquerdo.getValor() + noDireito.getValor();
		this.peso = noEsquerdo.getPeso() + noDireito.getPeso();
		this.noEsquerdo = noEsquerdo;
		this.noDireito = noDireito;
		setarCaminho("");
	}
	
	private void setarCaminho(String caminho) {
		this.caminho = caminho;
		if(this.noDireito != null){
			this.noEsquerdo.setarCaminho(caminho + "0");
		}
		if(this.noEsquerdo != null){
			this.noDireito.setarCaminho(caminho + "1");
		}
	}

	public int getPeso() {
		return peso;
	}
	public void setPeso(int peso) {
		this.peso = peso;
	}
	public String getValor() {
		return valor;
	}
	public void setValor(String valor) {
		this.valor = valor;
	}
	public NoArvore getNoEsquerdo() {
		return noEsquerdo;
	}
	public void setNoEsquerdo(NoArvore noEsquerdo) {
		this.noEsquerdo = noEsquerdo;
		this.noEsquerdo.setarCaminho(caminho + "0");
	}
	public NoArvore getNoDireito() {
		return noDireito;
	}
	public void setNoDireito(NoArvore noDireito) {
		this.noDireito = noDireito;
		this.noDireito.setarCaminho(caminho + "1");
	}
	public boolean ehNoFolha(){
		return noDireito == null && noEsquerdo == null;
	}

	@Override
	public int compareTo(NoArvore o) {
		return this.peso - o.peso;
	}
	
	@Override
	public String toString(){
		return "<" + valor + (noEsquerdo != null? noEsquerdo.toString() : "<>") + (noDireito != null? noDireito.toString() : "<>") +">";
	}

	public String getCaminho() {
		return this.caminho;
	}

	public List<NoArvore> obterNosFolhas() {
		List<NoArvore> retorno = new ArrayList<NoArvore>();
		if(noEsquerdo != null){
			for(NoArvore no : noEsquerdo.obterNosFolhas()){
				retorno.add(no);
			}
		}
		if(noDireito != null){
			for(NoArvore no : noDireito.obterNosFolhas()){
				retorno.add(no);			
			}
		}
		if(this.ehNoFolha()){
			retorno.add(this);
		}
		return retorno;
	}
}