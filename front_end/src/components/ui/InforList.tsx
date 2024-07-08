import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import StarIcon from '@mui/icons-material/Star';
import AccessTimeIcon from '@mui/icons-material/AccessTime';
import DateRangeIcon from '@mui/icons-material/DateRange';

export interface IInforItem {
    rating: number;
    date: string;
    quality: string;
    period: string;
}

const InforList = ({ item, color }: { item: IInforItem; color: string }) => {
    const [datePart] = item.date.split(' ');
    const [year] = datePart.split('-');

    return (
        <Box sx={{ display: 'flex', alignItems: 'center', paddingBottom: '6.4px' }}>
            <Typography
                sx={{
                    fontSize: '12px',
                    display: 'flex',
                    alignItems: 'center',
                    marginRight: '8px',
                    color: '#b5e745',
                }}
            >
                <StarIcon sx={{ fontSize: '14px', marginRight: '4px' }} />
                {item.rating}
            </Typography>
            <Typography
                sx={{
                    fontSize: '12px',
                    display: 'flex',
                    alignItems: 'center',
                    marginRight: '8px',
                    color: color,
                }}
            >
                <AccessTimeIcon sx={{ fontSize: '14px', marginRight: '4px' }} />
                {item.period}
            </Typography>
            <Typography
                sx={{
                    fontSize: '12px',
                    display: 'flex',
                    alignItems: 'center',
                    marginRight: '8px',
                    color: color,
                }}
            >
                <DateRangeIcon sx={{ fontSize: '14px', marginRight: '4px' }} />
                {year}
            </Typography>
            <Typography
                sx={{
                    fontSize: '12px',
                    backgroundColor: '#e62117',
                    borderRadius: '10px',
                    paddingX: '9.6px',
                }}
            >
                {item.quality}
            </Typography>
        </Box>
    );
};

export default InforList;
