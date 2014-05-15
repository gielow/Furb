package Algoritmo;

public class FrequenciaLetra implements Comparable<FrequenciaLetra>{ 
	private int frequencia;
	private char letra;
	
	public FrequenciaLetra(char letra){
		this.letra = letra;
	}
	
	public void IncrementarQtdOcorrencias() {
		frequencia++;		
	}

	public char getLetra() {
		return letra;
	}

	public int getFrequencia() {
		return frequencia;
	}
	
	public boolean equals(Object obj){
		if (obj == null)
            return false;
        if (obj == this)
            return true;
        if (!(obj instanceof FrequenciaLetra))
            return false;
        
        FrequenciaLetra other = (FrequenciaLetra)obj;
        boolean result = this.getLetra() == other.getLetra(); 
        return result;
	}
	
	public int compareTo(FrequenciaLetra compareFrequencia) {
		return this.frequencia - compareFrequencia.frequencia; 
	}
}
