class OrganicRiceSimulation
{
    private CropModel crop;
    private SoilModel soil;

    static void main()
    {
        OrganicRiceSimulation ors = new OrganicRiceSimulation();
        ors.initialize();

        while (ors.nextTimeStep())
        {
            ors.performTimeStep();
        }

        ors.finish();

    }

    void initialize()
    {
        crop = new CropModel();
        soil = new SoilModel();
        crop.initialize();
        soil.initialize();
    // set starting date & simulation config
        this.startdoy = 120;
        this.lastdoy = 330;
    }

    bool nextTimeStep()
    {
        if (this.lastdoy < this.doy++)
            return false;
        return crop.harvested();
    }

    void performTimeStep()
    {
        rate();
        integrate();
        output();
    }

    void rate()
    {
        crop.rate();
        soil.rate();
    }

    void integrate()
    {
        crop.integrate();
        soil.integrate();
    }

    void output()
    {
        crop.output();
        soil.output();
    }

    void finish()
    {
        crop.finish();
        soil.finish();
    }
}



