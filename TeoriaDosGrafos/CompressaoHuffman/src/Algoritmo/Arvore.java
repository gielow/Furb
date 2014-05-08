package Algoritmo;

import java.util.List;

public class Arvore {
	private NoArvore noPrincipal;

	public Arvore(NoArvore noPrincipal) {
		this.noPrincipal = noPrincipal;
	}

	public NoArvore getNoPrincipal() {
		return noPrincipal;
	}

	public void setNoPrincipal(NoArvore noPrincipal) {
		this.noPrincipal = noPrincipal;
	}
	
	@Override
	public String toString(){
		return noPrincipal.toString();
	}

	public List<NoArvore> obterNosFolhas() {
		return noPrincipal.obterNosFolhas();
	}
}
