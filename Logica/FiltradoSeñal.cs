public class FiltradoSeñal
{
    private double _valorSuavizado = 0;
    private double _alpha;

    public FiltradoSeñal(double alpha = 0.2)
    {
        _alpha = alpha;
    }

    public double FiltroSuavizadoExponencial(double valorActual)
    {
        _valorSuavizado = _alpha * valorActual + (1 - _alpha) * _valorSuavizado;
        return _valorSuavizado;
    }

    public double NormalizarDato(double valor)
    {
        return (512 - valor) / 512 * 100;
    }
}
